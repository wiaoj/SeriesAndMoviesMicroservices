using DirectorService.Application.Dtos;

namespace DirectorService.Application.Features.Queries.GetByIdDirectorQuery;
public sealed record GetByIdDirectorQueryResponse(DirectorDto Director);