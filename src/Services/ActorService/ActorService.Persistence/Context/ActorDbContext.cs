using ActorService.Domain;
using BuildingBlocks.Core.Persistence.MsSQL;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ActorService.Persistence.Context;
public sealed class ActorDbContext : MsSQLDatabaseContext {
    public ActorDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Actor> Actors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}