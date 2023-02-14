using Newtonsoft.Json;

namespace EventBus.Base.Events;
public class IntegrationEvent {

    [JsonProperty]
    public Guid Id { get; private set; }

    [JsonProperty]
    public DateTime CreatedDate { get; private set; }

    public IntegrationEvent() : this(Guid.NewGuid(), DateTime.UtcNow) { }

    [JsonConstructor] //bununla gerçekleştiği zaman dışarıdan gelen id ve createdDate ile set etmemizi sağlıyor
    public IntegrationEvent(Guid id, DateTime createdDate) {
        Id = id;
        CreatedDate = createdDate;
    }
}