using BuildingBlocks.Core.Abstractions.CQRS.Notifications;

namespace CategoryService.Domain.Events;
public class CategoryCreatedBusinessEvent : INotification {
    public Category.Category Category { get; set; }
    public CategoryCreatedBusinessEvent(Category.Category category) => Category = category;
}