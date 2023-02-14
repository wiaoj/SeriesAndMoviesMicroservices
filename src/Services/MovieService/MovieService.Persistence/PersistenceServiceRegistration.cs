using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MovieService.Persistence.Context;

namespace MovieService.Persistence;
public static class PersistenceServiceRegistration {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {

        //services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(MovieDbContext.MsSQL_CONNECTION_STRING));
        services.AddDbContext<MovieDbContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString(MovieDbContext.MsSQL_CONNECTION_STRING));
        });

        return services;
    }
}