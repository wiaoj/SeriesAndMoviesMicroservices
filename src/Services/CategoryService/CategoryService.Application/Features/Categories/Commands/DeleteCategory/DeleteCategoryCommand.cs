using BuildingBlocks.Core.Abstractions.CQRS.Commands;
using BuildingBlocks.Core.Application.CQRS.Commands;
using CategoryService.Application.Services.Repositories;
using CategoryService.Contracts;
using CategoryService.Domain.Category;

namespace CategoryService.Application.Features.Categories.Commands.DeleteCategory;
public sealed class DeleteCategoryCommand : IRequestCommand<DeleteCategoryResponse> {
    public required Guid Id { get; set; }

    private class DeleteCategoryCommandHandler : RequestCommandHandler<DeleteCategoryCommand, DeleteCategoryResponse> {
        private readonly ICategoryWriteRepository _categoryWriteRepository;

        public DeleteCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository) {
            _categoryWriteRepository = categoryWriteRepository;
        }

        protected override async Task<DeleteCategoryResponse> HandleCommandAsync(DeleteCategoryCommand command, CancellationToken cancellationToken) {

            await _categoryWriteRepository.DeleteAsync(Category.GetId(command.Id), cancellationToken);
            await _categoryWriteRepository.SaveChangesAsync(cancellationToken);

            return new(
                Id: command.Id);
        }
    }
}