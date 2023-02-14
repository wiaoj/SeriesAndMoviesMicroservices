using IdentityService.Application.Common.Authentication;
using IdentityService.Application.Common.Persistence.Interfaces;
using IdentityService.Application.Repositories;
using IdentityService.Application.Repositories.RefreshTokens;
using IdentityService.Application.Services;
using IdentityService.Persistence.Context;
using IdentityService.Persistence.Repositories.ReadRepositories;
using IdentityService.Persistence.Repositories.WriteRepositories;
using IdentityService.Persistence.Services;
using IdentityService.Persistence.Services.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityService.Persistence;
public static class PersistenceServiceRegistration {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SECTION_NAME));

        services.AddDbContext<IdentityDbContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString(IdentityDbContext.MsSQL_CONNECTION_STRING));
            //options.UseInMemoryDatabase(IdentityDbContext.MsSQL_CONNECTION_STRING);
        });


        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserService, UserService>();

        services.AddScoped<IUserWriteRepository, UserWriteRepository>();
        services.AddScoped<IUserReadRepository, UserReadRepository>();

        services.AddScoped<IRefreshTokenWriteRepository, RefreshTokenWriteRepository>();
        services.AddScoped<IRefreshTokenReadRepository, RefreshTokenReadRepository>();
        return services;
    }
}