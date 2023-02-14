namespace EventBus.Base;
public class EventBusConfig {
    public Int32 ConnectionRetryCount { get; set; } = 5;
    public String DefaultTopicName { get; set; } = "SeriesAndMoviesEventBus";
    public String EventBusConnectionString { get; set; } = String.Empty;
    public String SubscriberClientApplicationName { get; set; } = String.Empty; //kuyruk isimlendirmenin başına yerleştirilecek
    public String EventNamePrefix { get; set; } = String.Empty;
    public String EventNameSuffix { get; set; } = "IntegrationEvent";
    public EventBusType EventBusType { get; set; } = EventBusType.RabbitMQ;
    public Object Connection { get; set; } = null!;//kullanılan eventbus kütüphanesine göre cast edilecek
    public Int32 Port { get; set; }
    public Boolean DeleteEventPrefix => String.IsNullOrEmpty(EventNamePrefix) is false;
    public Boolean DeleteEventSuffix => String.IsNullOrEmpty(EventNameSuffix) is false;
}