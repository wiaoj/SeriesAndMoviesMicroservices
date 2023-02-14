using BuildingBlocks.Core.Abstractions.Domain.Models;

namespace CategoryService.Domain.Category.ValueObjects;
public sealed class CategoryId : ValueObject {
    public Guid Value { get; }
    private CategoryId(Guid value) => Value = value;
    public static CategoryId CreateUnique => new(Guid.NewGuid());
    public static CategoryId Parse(Guid id) {
        return new(id);
    }
    public override IEnumerable<Object> GetEqualityComponents() {
        yield return Value;
    }

    //public static implicit operator Guid(CategoryId id) => id.Value;
    public static implicit operator CategoryId(Guid id) => new(id);
}