using EventBus.Base.Events;

namespace EventBus.Base.Abstraction;
public interface IEventBusSubscriptionManager {
    public Boolean IsEmpty { get; } //event dinleniyor mu
    public event EventHandler<String> OnEventRemoved; //unsubscription çalışınca çalışacak
    public void AddSubscription<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;
    public void RemoveSubscription<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;
    public Boolean HasSubscriptionForEvent<T>() where T : IntegrationEvent; //event gelince dinleyecek mi diye kontrol blic edecek
    public Boolean HasSubscriptionForEvent(String eventName);
    public Type? GetEventTypeByName(String eventName);
    public void Clear();
    public IEnumerable<SubscriptionInfo> GetHandlersForEvent<T>() where T : IntegrationEvent; //eventin tüm subslarını blic updöneceğimiz bir metod
    public IEnumerable<SubscriptionInfo> GetHandlersForEvent(String eventName);
    public String GetEventKey<T>() where T : IntegrationEvent; //integration event key
}