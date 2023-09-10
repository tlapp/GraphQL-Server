using GraphQL.Sessions;
using GraphQL.Speakers;
using GraphQL.Tracks;
using GraphQL.Types;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureGraphQL
{
    public static IServiceCollection AddGraphQL(this IServiceCollection services)
    {
        services.AddGraphQLServer()
            .AddQueryType(d => d.Name("Query"))
                .AddTypeExtension<SpeakerQueries>()
            .AddMutationType(d => d.Name("Mutation"))
                .AddTypeExtension<SpeakerMutations>()
                .AddTypeExtension<SessionMutations>()
                .AddTypeExtension<TracksMutations>()
            .AddType<AttendeeType>()
            .AddType<SpeakerType>()
            .AddType<SessionType>()
            .AddType<TrackType>()
            .EnableRelaySupport();

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
