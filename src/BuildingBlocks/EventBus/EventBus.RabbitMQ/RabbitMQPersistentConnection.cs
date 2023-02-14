using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System.Net.Sockets;

namespace EventBus.RabbitMQ;
public class RabbitMQPersistentConnection : IDisposable {
    private readonly IConnectionFactory _connectionFactory;
    private IConnection _connection;
    private readonly Object _lockObject = new();
    private readonly Int32 _retryCount;
    private Boolean _disposed;
    public Boolean IsConnection => _connection is not null && _connection.IsOpen;

    public RabbitMQPersistentConnection(
        IConnectionFactory connectionFactory,
        Int32 retryCount = 5
        ) {
        _connectionFactory = connectionFactory;
        _retryCount = retryCount;
    }

    public IModel CreateModel() => _connection.CreateModel();

    public void Dispose() {
        _disposed = true;
        _connection.Dispose();
    }

    public Boolean TryConnect() {
        lock(_lockObject) {
            var policy = Policy.Handle<SocketException>()
                .Or<BrokerUnreachableException>()
                .WaitAndRetry(_retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (exception, time) => { }
                );

            policy.Execute(() => {
                _connection = _connectionFactory.CreateConnection();
            });

            if(IsConnection) {
                _connection.ConnectionShutdown += ConnectionShutown;
                _connection.CallbackException += CallbackException;
                _connection.ConnectionBlocked += ConnectionBlocked;
                //log

                return true;
            }

            return false;
        }
    }

    private void ConnectionBlocked(Object? sender, ConnectionBlockedEventArgs eventArgs) {
        if(_disposed)
            return;
        TryConnect();
    }

    private void CallbackException(Object? sender, CallbackExceptionEventArgs eventArgs) {
        if(_disposed)
            return;
        TryConnect();
    }

    private void ConnectionShutown(Object? sender, ShutdownEventArgs eventArgs) {
        if(_disposed)
            return;
        TryConnect();
    }
}