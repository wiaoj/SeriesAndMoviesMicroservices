using EventBus.Base.Abstraction;
using EventBus.Base.SubscriptionManagers;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace EventBus.Base.Events;
public abstract class BaseEventBus : IEventBus {
    public readonly IServiceProvider ServiceProvider;
    public readonly IEventBusSubscriptionManager SubscriptionManager;
    protected EventBusConfig EventBusConfig { get; set; }

    public BaseEventBus(
        EventBusConfig eventBusConfig,
        IServiceProvider serviceProvider
        ) {
        EventBusConfig = eventBusConfig;
        ServiceProvider = serviceProvider;
        SubscriptionManager = new InMemoryEventBusSubscriptionManager(ProcessEventName);
    }

    public virtual String ProcessEventName(String eventName) {
        //if(EventBusConfig.DeleteEventPrefix)
        //    eventName = eventName.TrimStart(EventBusConfig.EventNamePrefix.ToArray());

        //if(EventBusConfig.DeleteEventSuffix)
        //    eventName = eventName.TrimEnd(EventBusConfig.EventNameSuffix.ToArray());

        eventName = EventBusConfig.DeleteEventPrefix ?
             eventName.TrimStart(EventBusConfig.EventNamePrefix.ToArray()) : eventName;

        eventName = EventBusConfig.DeleteEventSuffix ?
             eventName.TrimEnd(EventBusConfig.EventNameSuffix.ToArray()) : eventName;

        return eventName;
    }

    public virtual String GetSubName(String eventName)
        => $"{EventBusConfig?.SubscriberClientApplicationName}.{ProcessEventName(eventName)}";

    public virtual void Dispose() {
        EventBusConfig = null!;
        SubscriptionManager.Clear();
    }

    public async Task<Boolean> ProcessEvent(String eventName, String message) {
        eventName = ProcessEventName(eventName);

        Boolean processed = default;

        if(SubscriptionManager.HasSubscriptionForEvent(eventName) is false) //event takip ediliyor mu dinliyorsak devam ediyoruz içinde
            return processed;

        IEnumerable<SubscriptionInfo> subscriptions = SubscriptionManager.GetHandlersForEvent(eventName); //kaç kişi subscriber oluyo

        await using AsyncServiceScope scope = ServiceProvider.CreateAsyncScope();

        foreach(SubscriptionInfo subscription in subscriptions) { //subscriptionlara gönderiyoruz
            Object? handler = ServiceProvider.GetService(subscription.HandlerType); //DI ile servisi alıyoruz dinamik olarak

            if(handler is null)
                continue;

            //type'ına ulaşıyoruz
            Type? eventType = SubscriptionManager.GetEventTypeByName($"{EventBusConfig.EventNamePrefix}{eventName}{EventBusConfig.EventNameSuffix}");

            Object? integrationEvent = JsonConvert.DeserializeObject(message, eventType);

            Type? concreteType = typeof(IIntegrationEventHandler<>).MakeGenericType(eventType); //reflection ile metoda ulaşıyoruz
            await Task.Run(() => {
                concreteType?.GetMethod("Handle")?.Invoke(handler, new[] { integrationEvent });
            });
        }

        processed = true;

        return processed;
    }

    public abstract void Publish(IntegrationEvent @event);
    public abstract void Subscribe<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;
    public abstract void UnSubscribe<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;
}