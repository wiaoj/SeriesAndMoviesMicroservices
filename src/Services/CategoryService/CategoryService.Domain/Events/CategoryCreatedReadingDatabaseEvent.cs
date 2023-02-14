using BuildingBlocks.Core.Abstractions.CQRS.Notifications;

namespace CategoryService.Domain.Events;

public class CategoryCreatedReadingDatabaseEvent : INotification {
    public Category.Category Category { get; set; }
    public CategoryCreatedReadingDatabaseEvent(Category.Category category) => Category = category;
}