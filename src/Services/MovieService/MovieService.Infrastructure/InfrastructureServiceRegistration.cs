﻿using Microsoft.Extensions.DependencyInjection;

namespace MovieService.Infrastructure;
public static class InfrastructureServiceRegistration {
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services) {
        return services;
    }
}