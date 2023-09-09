﻿using GraphQL.Data;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigurePersistence
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlite("Data Source=conferences.db"));
        return services;
    }
}