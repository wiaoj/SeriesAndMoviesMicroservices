using ActorService.Application.Services.Repositories;
using ActorService.Domain;
using ActorService.Domain.ValueObjects;
using BuildingBlocks.Core.Abstractions.CQRS.Queries;
using BuildingBlocks.Core.Application.CQRS.Queries;
using ActorService.Application.Dtos;

namespace ActorService.Application.Features.Queries.GetByIdActorQuery;
public sealed class GetByIdActorQueryRequest : IRequestQuery<GetByIdActorQueryResponse> {
    public required ActorId Id { get; set; }

    private class Handler : RequestQueryHandler<GetByIdActorQueryRequest, GetByIdActorQueryResponse> {
        private readonly IActorReadRepository _directorReadRepository;

        public Handler(IActorReadRepository directorReadRepository) {
            _directorReadRepository = directorReadRepository;
        }

        protected override async Task<GetByIdActorQueryResponse> HandleQueryAsync(GetByIdActorQueryRequest query, CancellationToken cancellationToken) {
            Actor director = await _directorReadRepository.GetByIdAsync(query.Id, cancellationToken)
                ?? throw new Exception("Director not found");
            ActorDto mappedDirector = new(director.Id.Value,
                                             director.FirstName,
                                             director.LastName,
                                             director.Age,
                                             director.Country,
                                             director.Biography);
            return new(mappedDirector);
        }
    }
}