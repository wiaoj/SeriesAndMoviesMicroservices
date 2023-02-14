using BuildingBlocks.Core.Abstractions.Domain.Models;

namespace DirectorService.Domain.ValueObjects;
public sealed class DirectorId : ValueObject {
    public Guid Value { get; private set; }

    private DirectorId(Guid value) {
        Value = value;
    }

    public static DirectorId CreateUnique => new(Guid.NewGuid());
    public static DirectorId Create(Guid value) => new(value);

    public override IEnumerable<Object> GetEqualityComponents() {
        yield return Value;
    }
}