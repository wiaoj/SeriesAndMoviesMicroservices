using BuildingBlocks.Core.Persistence.MsSQL;
using CategoryService.Domain.Category;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CategoryService.Persistence.Contexts;
public class CategoryDbContext : MsSQLDatabaseContext {
    public const String TABLE_NAME = "category";
    public const String DEFAULT_SCHEMA = "category";

    public CategoryDbContext(DbContextOptions<CategoryDbContext> options) : base(options) { }


    public DbSet<Category> Categories => Set<Category>();


    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}