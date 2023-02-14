using BuildingBlocks.Core.Abstractions.CQRS.Queries;
using BuildingBlocks.Core.Application.CQRS.Queries;
using DirectorService.Application.Dtos;
using DirectorService.Application.Services.Repositories;
using DirectorService.Domain;
using DirectorService.Domain.ValueObjects;

namespace DirectorService.Application.Features.Queries.GetByIdDirectorQuery;
public sealed class GetByIdDirectorQueryRequest : IRequestQuery<GetByIdDirectorQueryResponse> {
    public required DirectorId Id { get; set; }

    private class Handler : RequestQueryHandler<GetByIdDirectorQueryRequest, GetByIdDirectorQueryResponse> {
        private readonly IDirectorReadRepository _directorReadRepository;

        public Handler(IDirectorReadRepository directorReadRepository) {
            _directorReadRepository = directorReadRepository;
        }

        protected override async Task<GetByIdDirectorQueryResponse> HandleQueryAsync(GetByIdDirectorQueryRequest query, CancellationToken cancellationToken) {
            Director director = await _directorReadRepository.GetByIdAsync(query.Id, cancellationToken)
                ?? throw new Exception("Director not found");
            DirectorDto mappedDirector = new(director.Id.Value,
                                             director.FirstName,
                                             director.LastName,
                                             director.Age,
                                             director.Country,
                                             director.Biography);
            return new(mappedDirector);
        }
    }
}