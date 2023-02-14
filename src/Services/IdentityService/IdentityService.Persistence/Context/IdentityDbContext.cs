using BuildingBlocks.Core.Persistence.MsSQL;
using IdentityService.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IdentityService.Persistence.Context;
public class IdentityDbContext : MsSQLDatabaseContext {
    public const String TABLE_NAME = "identity";
    public const String DEFAULT_SCHEMA = "identity";
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options) { }

    //public DbSet<User> Users => Set<User>();
    public DbSet<User> Users { get; set; }
    //public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //base.OnModelCreating(modelBuilder);
    }
}