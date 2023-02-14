using EventBus.Base.Events;

namespace EventBus.Base.Abstraction;
public interface IIntegrationEventHandler<TIntegrationEvent> : IIntegrationEventHandler where TIntegrationEvent : IntegrationEvent {
    public Task Handle(TIntegrationEvent @event);
}

public interface IIntegrationEventHandler { }