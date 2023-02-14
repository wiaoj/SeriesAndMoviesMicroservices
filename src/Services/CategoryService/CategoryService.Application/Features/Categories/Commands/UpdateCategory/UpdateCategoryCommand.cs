using BuildingBlocks.Core.Abstractions.CQRS.Commands;
using BuildingBlocks.Core.Application.CQRS.Commands;
using CategoryService.Application.Services.Repositories;
using CategoryService.Contracts;

namespace CategoryService.Application.Features.Categories.Commands.UpdateCategory;
public sealed class UpdateCategoryCommand : IRequestCommand<UpdateCategoryResponse> {
    public required Guid Id { get; set; }
    public required String Name { get; set; }
    public required String? Description { get; set; }

    private class UpdateCategoryCommandHandler : RequestCommandHandler<UpdateCategoryCommand, UpdateCategoryResponse> {
        private readonly ICategoryWriteRepository _categoryWriteRepository;

        public UpdateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository) {
            _categoryWriteRepository = categoryWriteRepository;
        }

        protected override async Task<UpdateCategoryResponse> HandleCommandAsync(UpdateCategoryCommand command, CancellationToken cancellationToken) {
            //await _categoryWriteRepository.UpdateAsync(,cancellationToken)
            return default!;
        }
    }
}