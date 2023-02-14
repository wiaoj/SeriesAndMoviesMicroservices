using BuildingBlocks.Core.Abstractions.Domain.Models;

namespace MovieService.Domain.Movie.ValueObjects;
public sealed class MovieId : ValueObject {
    public Guid Value { get; }
    private MovieId(Guid value) => Value = value;

    public static MovieId Create() {
        return new(Guid.NewGuid());
    }
    
    public static MovieId Create(Guid value) {
        return new(value);
    }

    public override IEnumerable<Object> GetEqualityComponents() {
        yield return Value;
    }

    //public static implicit operator MovieId(Guid id) => new(id);
}