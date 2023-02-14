using BuildingBlocks.Core.Application.CQRS.Notifications;
using CategoryService.Application.Services.Repositories;
using CategoryService.Domain.Events;

namespace CategoryService.Application.Features.Categories.Events;
public class CategoryCreatedReadingDatabaseEventHandler : NotificationHandler<CategoryCreatedReadingDatabaseEvent> {
    private readonly ICategoryReadRepository _categoryReadRepository;

    public CategoryCreatedReadingDatabaseEventHandler(ICategoryReadRepository categoryReadRepository) {
        _categoryReadRepository = categoryReadRepository;
    }

    protected override Task HandleNotificationAsync(CategoryCreatedReadingDatabaseEvent notification, CancellationToken cancellationToken) {
        return Task.CompletedTask;
    }
}