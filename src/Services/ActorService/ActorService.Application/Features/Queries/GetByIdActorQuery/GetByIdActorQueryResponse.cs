using ActorService.Application.Dtos;

namespace ActorService.Application.Features.Queries.GetByIdActorQuery;
public sealed record GetByIdActorQueryResponse(ActorDto Actor);