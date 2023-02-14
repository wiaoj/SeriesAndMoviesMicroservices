using ActorService.Application.Services.Repositories;
using ActorService.Domain;
using ActorService.Domain.ValueObjects;
using ActorService.Persistence.Context;
using BuildingBlocks.Core.Persistence.EntityFrameworkCore.Repositories;

namespace ActorService.Persistence.Repositories;
public sealed class ActorReadRepository : ReadRepository<Actor, ActorId, ActorDbContext>, IActorReadRepository {
    public ActorReadRepository(ActorDbContext context) : base(context) { }
}