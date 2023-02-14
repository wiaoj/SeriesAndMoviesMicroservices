using BuildingBlocks.Core.Persistence.MsSQL;
using DirectorService.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DirectorService.Persistence.Context;
public sealed class DirectorDbContext : MsSQLDatabaseContext {
    public DirectorDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Director> Directors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}