using BuildingBlocks.Core.Abstractions.CQRS.Queries;
using BuildingBlocks.Core.Application.CQRS.Queries;
using DirectorService.Application.Dtos;
using DirectorService.Application.Services.Repositories;
using DirectorService.Domain;
using MediatR;

namespace DirectorService.Application.Features.Queries.GetAllDirectorsQuery;
public class GetAllDirectorsQueryRequest : IRequestQuery<GetAllDirectorsQueryResponse> {

    private sealed class Handler : RequestQueryHandler<GetAllDirectorsQueryRequest, GetAllDirectorsQueryResponse> {
        private readonly IDirectorReadRepository _directorReadRepository;

        public Handler(IDirectorReadRepository directorReadRepository) {
            _directorReadRepository = directorReadRepository;
        }

        protected override async Task<GetAllDirectorsQueryResponse> HandleQueryAsync(GetAllDirectorsQueryRequest query, CancellationToken cancellationToken) {
            IQueryable<Director>? directors = await _directorReadRepository.GetAllAsync(false, cancellationToken)
                ?? throw new Exception("Directors not found");

            IQueryable<DirectorDto> mappedDirectors = directors
                .Select(x => new DirectorDto(x.Id.Value,
                                             x.FirstName,
                                             x.LastName,
                                             x.Age,
                                             x.Country,
                                             x.Biography));
            return new(mappedDirectors);
        }
    }
}