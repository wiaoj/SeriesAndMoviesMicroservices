using BuildingBlocks.Core.Abstractions.CQRS.Commands;
using BuildingBlocks.Core.Application.CQRS.Commands;
using CategoryService.Application.Services.Repositories;
using CategoryService.Contracts;
using CategoryService.Domain.Category;

namespace CategoryService.Application.Features.Categories.Queries;
public sealed class GetByIdCategoriesQuery : IRequestCommand<GetByIdCategoryResponse> {
    public Guid Id { get; set; }
    private class GetByIdCategoriesQueryHandler : RequestCommandHandler<GetByIdCategoriesQuery, GetByIdCategoryResponse> {
        private readonly ICategoryReadRepository _categoryReadRepository;

        public GetByIdCategoriesQueryHandler(ICategoryReadRepository categoryReadRepository) {
            _categoryReadRepository = categoryReadRepository;
        }

        protected override async Task<GetByIdCategoryResponse> HandleCommandAsync(GetByIdCategoriesQuery command, CancellationToken cancellationToken) {
            var entity = await _categoryReadRepository.GetByIdAsync(Category.GetId(command.Id), cancellationToken);

            return new(
                Id: entity.Id,
                Name: entity.Name,
                Description: entity.Description);
        }
    }
}