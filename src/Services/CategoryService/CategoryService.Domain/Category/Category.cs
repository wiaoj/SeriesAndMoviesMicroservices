using BuildingBlocks.Core.Abstractions.Domain;
using BuildingBlocks.Core.Abstractions.Domain.Models;
using CategoryService.Domain.Category.ValueObjects;

namespace CategoryService.Domain.Category;
public sealed class Category : AggregateRoot<CategoryId>, IEntityHaveSoftDelete {
    public String Name { get; private set; }
    public String Description { get; private set; }
    private Category(CategoryId id, String name, String description) : base(id) {
        Name = name;
        Description = description;
    }

    public static Category Create(String name) {
        return Create(name, String.Empty);
    }
    public static Category Create(String name, String? description) {
        return new(CategoryId.CreateUnique, name, description ?? String.Empty);
    }

    public static CategoryId GetId(Guid id) => id;
}