using ActorService.Application.Dtos;

namespace ActorService.Application.Features.Queries.GetAllActorsQuery;
public record GetAllActorsQueryResponse(IQueryable<ActorDto> Actors);