using BuildingBlocks.Core.Abstractions.Domain;
using BuildingBlocks.Core.Persistence.EntityFrameworkCore.Conventions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BuildingBlocks.Core.Persistence.EntityFrameworkCore;
public abstract class DatabaseContextBase : DbContext {
    //private IDbContextTransaction? _currentTransaction;
    protected DatabaseContextBase(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        //AddingSoftDeletes(modelBuilder);
        //AddingVersioning(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder) {
        configurationBuilder.Conventions.Add(_ => new SnakeCaseConvention());
        base.ConfigureConventions(configurationBuilder);
    }

    private static void AddingSoftDeletes(ModelBuilder builder) {
        var types = builder.Model.GetEntityTypes().Where(x => x.ClrType.IsAssignableTo(typeof(IEntityHaveSoftDelete)));
        foreach(var entityType in types) {
            // 1. Add the IsDeleted property
            entityType.AddProperty(EntityFrameworkCoreConstants.SOFT_DELETE_PROPERTY_NAME, typeof(Boolean));

            // 2. Create the query filter
            var parameter = Expression.Parameter(entityType.ClrType);

            // EF.Property<bool>(TEntity, "IsDeleted")
            var propertyMethodInfo = typeof(EF).GetMethod("Property")?.MakeGenericMethod(typeof(Boolean));
            var isDeletedProperty = Expression.Call(propertyMethodInfo, parameter, Expression.Constant(EntityFrameworkCoreConstants.SOFT_DELETE_PROPERTY_NAME));

            // EF.Property<bool>(TEntity, "IsDeleted") == false
            BinaryExpression compareExpression =
                Expression.MakeBinary(ExpressionType.Equal, isDeletedProperty, Expression.Constant(false));

            // TEntity => EF.Property<bool>(TEntity, "IsDeleted") == false
            var lambda = Expression.Lambda(compareExpression, parameter);

            builder.Entity(entityType.ClrType).HasQueryFilter(lambda);
        }
    }
}