using ActorService.Persistence.Context;
using BuildingBlocks.Core.Persistence.EntityFrameworkCore.Repositories;
using ActorService.Application.Services.Repositories;
using ActorService.Domain;
using ActorService.Domain.ValueObjects;

namespace ActorService.Persistence.Repositories;
public sealed class ActorWriteRepository : WriteRepository<Actor, ActorId, ActorDbContext>, IActorWriteRepository {
    public ActorWriteRepository(ActorDbContext context) : base(context) { }
}