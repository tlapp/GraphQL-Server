using GraphQL.Presentation;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureGraphQL
{
    public static IServiceCollection AddGraphQL(this IServiceCollection services)
    {
        services.AddGraphQLServer()
            .AddQueryType<Query>()
            .AddMutationType<Mutation>();

        return services;
    }

    public static IApplicationBuilder AddGraphQLEndpoints(this IApplicationBuilder app)
    {
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGraphQL();
        });

        return app;
    }
}
