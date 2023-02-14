using BuildingBlocks.Core.Abstractions.Domain.Models;

namespace MovieService.Domain.Movie.ValueObjects;

public sealed class ActorId : ValueObject {
    public Guid Value { get; }
    private ActorId(Guid value) => Value = value;
    public static ActorId CreateUnique => new(Guid.NewGuid());
    public static ActorId Create(Guid value) => new(value);
    public override IEnumerable<Object> GetEqualityComponents() {
        yield return Value;
    }

    public static implicit operator ActorId(Guid id) => new(id);
}