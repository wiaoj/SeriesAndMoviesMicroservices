using BuildingBlocks.Core.Application.CQRS.Notifications;
using BuildingBlocks.Core.Domain.Exceptions;
using CategoryService.Application.Services.Repositories;
using CategoryService.Domain.Category;
using CategoryService.Domain.Events;

namespace CategoryService.Application.DomainEventHandlers;
public class CategoryCreatedBusinessEventHandler : NotificationHandler<CategoryCreatedBusinessEvent> {
    private readonly ICategoryReadRepository _categoryReadRepository;

    public CategoryCreatedBusinessEventHandler(ICategoryReadRepository categoryReadRepository) {
        _categoryReadRepository = categoryReadRepository;
    }

    protected override async Task HandleNotificationAsync(CategoryCreatedBusinessEvent notification, CancellationToken cancellationToken) {
        Category entity = notification.Category;

        var case1 = await _categoryReadRepository.FindAsync(x => x.Name.Equals(entity.Name), false, cancellationToken);

        if(case1.Any()) throw new Exception("Bu isimle bir kategori zaten mevcut");

        await Task.CompletedTask;
    }
}