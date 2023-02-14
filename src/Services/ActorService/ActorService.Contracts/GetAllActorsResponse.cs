using ActorService.Application.Dtos;

namespace ActorService.Contracts;
public sealed record GetAllActorsResponse(IQueryable<ActorDto> Actors);