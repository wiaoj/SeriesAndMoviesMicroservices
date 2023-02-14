using CategoryService.Application.Services.Repositories;
using CategoryService.Persistence.Contexts;
using CategoryService.Persistence.Contexts.Settings;
using CategoryService.Persistence.Repositories.ReadRepositories;
using CategoryService.Persistence.Repositories.WriteRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CategoryService.Persistence;
public static class PersistenceServiceRegistration {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {
        //services.Configure<CategoryDatabaseSettings>(configuration.GetSection(CategoryDatabaseSettings.SECTION_NAME));
        //services.AddDbContext<CategoryDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(CategoryDbContext.MsSQL_CONNECTION_STRING)));

        services.AddDbContext<CategoryDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(CategoryDbContext.MsSQL_CONNECTION_STRING)));
        //services.AddDbContext<CategoryDbContext>(options => options.UseInMemoryDatabase(nameof(CategoryDbContext)));

        services.AddSingleton<ICategoryDatabaseSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<CategoryDatabaseSettings>>().Value);

        services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
        services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();


        //services.AddTransient<IProductContext, ProductContext>();
        //services.AddTransient<IProductRepository, ProductRepository>();
        return services;
    }
}