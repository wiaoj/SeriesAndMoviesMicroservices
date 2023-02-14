using EventBus.Base.Abstraction;
using EventBus.Base.Events;

namespace CategoryService.WebAPI.Controllers;

public class TestIntegrationEvent : IntegrationEvent {
    public String Message { get; set; } = "Selam";
}

public class TestIntegrationEventHandler : IIntegrationEventHandler<TestIntegrationEvent> {
    private readonly IEventBus _eventBus;

    public TestIntegrationEventHandler(IEventBus eventBus) {
        _eventBus = eventBus;
    }

    public Task Handle(TestIntegrationEvent @event) {

        _eventBus.Publish(new TestSuccessIntegrationEvent(5));

        return Task.CompletedTask;
    }
}

public class TestSuccessIntegrationEvent : IntegrationEvent {
    public new int Id { get; set; }
    public TestSuccessIntegrationEvent(Int32 id) {
        Id = id;
    }
}