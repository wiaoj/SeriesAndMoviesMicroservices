using BuildingBlocks.Core.Abstractions.CQRS.Commands;
using BuildingBlocks.Core.Application.CQRS.Commands;
using CategoryService.Application.Services.Repositories;
using CategoryService.Contracts;
using CategoryService.Domain.Category;
using CategoryService.Domain.Events;
using MediatR;

namespace CategoryService.Application.Features.Categories.Commands.CreateCategory;
public sealed class CreateCategoryCommand : IRequestCommand<CreateCategoryResponse> {
    public required String Name { get; set; }
    public required String? Description { get; set; }

    private class CreateCategoryCommandHandler : RequestCommandHandler<CreateCategoryCommand, CreateCategoryResponse> {
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly IPublisher _publisher;
        public CreateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, IPublisher publisher) {
            _categoryWriteRepository = categoryWriteRepository;
            _publisher = publisher;
        }

        protected override async Task<CreateCategoryResponse> HandleCommandAsync(CreateCategoryCommand command, CancellationToken cancellationToken) {
            var category = Category.Create(command.Name, command.Description);


            await _categoryWriteRepository.AddAsync(category, cancellationToken);
            await _categoryWriteRepository.SaveChangesAsync(cancellationToken); 

            await _publisher.Publish(new CategoryCreatedBusinessEvent(category));

            return new(
                Id: category.Id,
                Name: category.Name,
                Description: category.Description);
        }
    }
}