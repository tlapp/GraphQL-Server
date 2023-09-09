using GraphQL.Data;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigurePersistence
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddPooledDbContextFactory<ApplicationDbContext>(options => 
            options.UseSqlite("Data Source=App_data\\conferences.db"));
        return services;
    }
}
