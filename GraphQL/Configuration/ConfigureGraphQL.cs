using GraphQL.DataLoader;
using GraphQL.Presentation;
using GraphQL.Types;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureGraphQL
{
    public static IServiceCollection AddGraphQL(this IServiceCollection services)
    {
        services.AddGraphQLServer()
            .AddQueryType<Query>()
            .AddMutationType<Mutation>()
            .AddType<SpeakerType>()
            .AddDataLoader<SpeakerByIdDataLoader>()
            .AddDataLoader<SessionByIdDataLoader>();

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
