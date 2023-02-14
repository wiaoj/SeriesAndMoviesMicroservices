using BuildingBlocks.Core.Abstractions.CQRS.Commands;
using BuildingBlocks.Core.Application.CQRS.Commands;
using CategoryService.Application.Services.Repositories;
using CategoryService.Contracts;

namespace CategoryService.Application.Features.Categories.Queries;
public sealed class GetAllCategoriesQuery : IRequestCommand<GetAllCategoriesResponse> {
    private class GetAllCategoriesQueryHandler : RequestCommandHandler<GetAllCategoriesQuery, GetAllCategoriesResponse> {
        private readonly ICategoryReadRepository _categoryReadRepository;

        public GetAllCategoriesQueryHandler(ICategoryReadRepository categoryReadRepository) {
            _categoryReadRepository = categoryReadRepository;
        }

        protected override async Task<GetAllCategoriesResponse> HandleCommandAsync(GetAllCategoriesQuery command, CancellationToken cancellationToken) {
            var entities = await _categoryReadRepository.GetAllAsync(cancellationToken);

            return new(
                Categories: entities);
        }
    }
}