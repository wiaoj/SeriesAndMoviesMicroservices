using ActorService.Application.Dtos;
using ActorService.Application.Services.Repositories;
using ActorService.Domain;
using BuildingBlocks.Core.Abstractions.CQRS.Queries;
using BuildingBlocks.Core.Application.CQRS.Queries;

namespace ActorService.Application.Features.Queries.GetAllActorsQuery;
public class GetAllActorsQueryRequest : IRequestQuery<GetAllActorsQueryResponse> {

    private sealed class Handler : RequestQueryHandler<GetAllActorsQueryRequest, GetAllActorsQueryResponse> {
        private readonly IActorReadRepository _directorReadRepository;

        public Handler(IActorReadRepository directorReadRepository) {
            _directorReadRepository = directorReadRepository;
        }

        protected override async Task<GetAllActorsQueryResponse> HandleQueryAsync(GetAllActorsQueryRequest query, CancellationToken cancellationToken) {
            IQueryable<Actor>? directors = await _directorReadRepository.GetAllAsync(false, cancellationToken)
                ?? throw new Exception("Directors not found");

            IQueryable<ActorDto> mappedDirectors = directors
                .Select(x => new ActorDto(x.Id.Value,
                                             x.FirstName,
                                             x.LastName,
                                             x.Age,
                                             x.Country,
                                             x.Biography));
            return new(mappedDirectors);
        }
    }
}