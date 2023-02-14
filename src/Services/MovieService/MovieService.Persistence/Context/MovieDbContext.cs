using BuildingBlocks.Core.Persistence.MsSQL;
using Microsoft.EntityFrameworkCore;
using MovieService.Domain.Movie;
using System.Reflection;

namespace MovieService.Persistence.Context;
public class MovieDbContext : MsSQLDatabaseContext {
    public const String TABLE_NAME = "movie";
    public const String DEFAULT_SCHEMA = "movie";

    public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }


    public DbSet<Movie> Movies => Set<Movie>();


    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //base.OnModelCreating(modelBuilder);
    }
}