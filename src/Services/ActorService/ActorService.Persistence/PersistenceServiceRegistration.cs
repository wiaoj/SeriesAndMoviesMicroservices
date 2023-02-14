using ActorService.Persistence.Context;
using ActorService.Persistence.Repositories;
using ActorService.Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ActorService.Persistence;
public static class PersistenceServiceRegistration {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {

        services.AddDbContext<ActorDbContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString(BuildingBlocks.Core.Persistence.MsSQL.MsSQLDatabaseContext.MsSQL_CONNECTION_STRING));
        });


        services.AddScoped<IActorReadRepository, ActorReadRepository>();
        services.AddScoped<IActorWriteRepository, ActorWriteRepository>();

        return services;
    }
}