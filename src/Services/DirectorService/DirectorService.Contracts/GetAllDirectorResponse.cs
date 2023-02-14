using DirectorService.Application.Dtos;

namespace DirectorService.Contracts;
public sealed record GetAllDirectorsResponse(IQueryable<DirectorDto> Directors);