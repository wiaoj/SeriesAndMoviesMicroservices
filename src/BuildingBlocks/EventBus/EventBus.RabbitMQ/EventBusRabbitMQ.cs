using EventBus.Base;
using EventBus.Base.Events;
using Newtonsoft.Json;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System.Net.Sockets;
using System.Text;

namespace EventBus.RabbitMQ;
public class EventBusRabbitMQ : BaseEventBus {
    private readonly RabbitMQPersistentConnection _persistentConnection;
    private readonly IConnectionFactory _connectionFactory;
    private readonly IModel _consumerChannel;

    public EventBusRabbitMQ(IConnectionFactory connectionFactory, IServiceProvider serviceProvider) : base(new(),serviceProvider){
        _connectionFactory = connectionFactory;
        _persistentConnection = new(_connectionFactory, 5);

        _consumerChannel = CreateConsumerChannel();

        SubscriptionManager.OnEventRemoved += this.SubscriptionManager_OnEventRemoved;
    }
    public EventBusRabbitMQ(EventBusConfig eventBusConfig, IServiceProvider serviceProvider)
        : base(eventBusConfig, serviceProvider) {
        if(eventBusConfig.Connection is not null) {
            var connectionJson = JsonConvert.SerializeObject(EventBusConfig.Connection, new JsonSerializerSettings() {
                // Self referencing loop detected for property
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            });

            _connectionFactory = JsonConvert.DeserializeObject<ConnectionFactory>(connectionJson);
        } else
            _connectionFactory = new ConnectionFactory();

        _persistentConnection = new(_connectionFactory, eventBusConfig.ConnectionRetryCount);

        _consumerChannel = CreateConsumerChannel();

        SubscriptionManager.OnEventRemoved += this.SubscriptionManager_OnEventRemoved;
    }

    private void SubscriptionManager_OnEventRemoved(Object? sender, String eventName) {
        eventName = ProcessEventName(eventName);

        if(_persistentConnection.IsConnection is false) {
            _persistentConnection.TryConnect();
        }

        _consumerChannel.QueueUnbind(
            queue: eventName,
            exchange: EventBusConfig.DefaultTopicName,
            routingKey: eventName
            );

        if(SubscriptionManager.IsEmpty) {
            _consumerChannel.Close();
        }
    }

    public override void Publish(IntegrationEvent @event) {
        if(_persistentConnection.IsConnection) {
            _persistentConnection.TryConnect();
        }

        var policy = Policy.Handle<BrokerUnreachableException>()
            .Or<SocketException>()
            .WaitAndRetry(EventBusConfig.ConnectionRetryCount, retryAttempt =>
                TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (exception, time) => { /* loging */ }
            );

        var eventName = @event.GetType().Name;
        eventName = ProcessEventName(eventName);

        _consumerChannel.ExchangeDeclare(exchange: EventBusConfig.DefaultTopicName, type: "direct"); // Ensure exchange exists while publishing

        _consumerChannel.QueueUnbind(
            queue: eventName,
            exchange: EventBusConfig.DefaultTopicName,
            routingKey: eventName
            );

        var message = JsonConvert.SerializeObject(@event);
        var body = Encoding.UTF8.GetBytes(message); //rabbitmq byte olarak istiyor

        policy.Execute(() => {
            var properties = _consumerChannel.CreateBasicProperties();
            properties.DeliveryMode = 2; // Persistent

            _consumerChannel.QueueDeclare(queue: GetSubName(eventName), // Ensure queue exists while consuming
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
                );

            _consumerChannel.BasicPublish(
                exchange: EventBusConfig.DefaultTopicName,
                routingKey: eventName,
                mandatory: true,
                basicProperties: properties,
                body: body
                );
        });
    }

    public override void Subscribe<T, TH>() {
        var eventName = typeof(T).Name;
        eventName = ProcessEventName(eventName);

        if(SubscriptionManager.HasSubscriptionForEvent(eventName) is false) {
            if(_persistentConnection.IsConnection is false) {
                _persistentConnection.TryConnect();
            }

            _consumerChannel.QueueDeclare(queue: GetSubName(eventName), // Ensure queue exists while consuming
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
                );

            _consumerChannel.QueueBind(queue: GetSubName(eventName),
                exchange: EventBusConfig.DefaultTopicName,
                routingKey: eventName
                );
        }

        SubscriptionManager.AddSubscription<T, TH>();
        StartBasicConsume(eventName);
    }

    public override void UnSubscribe<T, TH>() {
        SubscriptionManager.RemoveSubscription<T, TH>();
    }

    private IModel CreateConsumerChannel() {
        if(_persistentConnection.IsConnection is false) {
            _persistentConnection.TryConnect();
        }

        var channel = _persistentConnection.CreateModel();

        channel.ExchangeDeclare(exchange: EventBusConfig.DefaultTopicName, type: "direct");

        return channel;
    }

    private void StartBasicConsume(String eventName) {
        if(_consumerChannel is not null) {
            var consumer = new EventingBasicConsumer(_consumerChannel);

            consumer.Received += Received;

            _consumerChannel.BasicConsume(
                queue: GetSubName(eventName),
                autoAck: false,
                consumer: consumer
                );
        }
    }

    private async void Received(Object sender, BasicDeliverEventArgs eventArgs) {
        var eventName = eventArgs.RoutingKey;
        eventName = ProcessEventName(eventName);

        var message = Encoding.UTF8.GetString(eventArgs.Body.Span);

        try {
            await ProcessEvent(eventName, message);
        } catch(Exception) { /*logging*/ }

        _consumerChannel.BasicAck(eventArgs.DeliveryTag, multiple: false);
    }
}
