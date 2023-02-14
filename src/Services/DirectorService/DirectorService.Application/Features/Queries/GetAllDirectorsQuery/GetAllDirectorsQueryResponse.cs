using DirectorService.Application.Dtos;
using DirectorService.Domain;

namespace DirectorService.Application.Features.Queries.GetAllDirectorsQuery;
public record GetAllDirectorsQueryResponse(IQueryable<DirectorDto> Directors);