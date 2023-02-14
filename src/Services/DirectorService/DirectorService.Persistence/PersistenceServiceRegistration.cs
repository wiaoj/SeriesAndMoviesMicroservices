using DirectorService.Application.Services.Repositories;
using DirectorService.Persistence.Context;
using DirectorService.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DirectorService.Persistence;
public static class PersistenceServiceRegistration {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {

        services.AddDbContext<DirectorDbContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString(DirectorDbContext.MsSQL_CONNECTION_STRING));
        });


        services.AddScoped<IDirectorReadRepository, DirectorReadRepository>();
        services.AddScoped<IDirectorWriteRepository, DirectorWriteRepository>();

        return services;
    }
}