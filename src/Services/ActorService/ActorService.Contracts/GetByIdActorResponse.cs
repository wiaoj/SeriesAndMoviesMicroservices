using ActorService.Application.Dtos;

namespace ActorService.Contracts;
public sealed record GetByIdActorResponse(ActorDto Actor);