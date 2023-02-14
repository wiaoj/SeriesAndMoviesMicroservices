using ActorService.Domain;
using ActorService.Domain.ValueObjects;
using BuildingBlocks.Core.Abstractions.Repositories;

namespace ActorService.Application.Services.Repositories;
public interface IActorWriteRepository : IAsyncWriteRepository<Actor, ActorId> { }