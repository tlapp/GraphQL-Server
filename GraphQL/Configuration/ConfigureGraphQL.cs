using GraphQL.Attendees;
using GraphQL.DataLoader;
using GraphQL.Sessions;
using GraphQL.Speakers;
using GraphQL.Tracks;
using GraphQL.Types;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureGraphQL
{
    public static IServiceCollection AddGraphQL(this IServiceCollection services)
    {
        services
               .AddGraphQLServer()
               .AddQueryType(d => d.Name("Query"))
                   .AddTypeExtension<AttendeeQueries>()
                   .AddTypeExtension<SpeakerQueries>()
                   .AddTypeExtension<SessionQueries>()
                   .AddTypeExtension<TrackQueries>()
               .AddMutationType(d => d.Name("Mutation"))
                   .AddTypeExtension<AttendeeMutations>()
                   .AddTypeExtension<SessionMutations>()
                   .AddTypeExtension<SpeakerMutations>()
                   .AddTypeExtension<TrackMutations>()
               .AddSubscriptionType(d => d.Name("Subscription"))
                   .AddTypeExtension<AttendeeSubscriptions>()
                   .AddTypeExtension<SessionSubscriptions>()
               .AddType<AttendeeType>()
               .AddType<SessionType>()
               .AddType<SpeakerType>()
               .AddType<TrackType>()
               .EnableRelaySupport()
               .AddFiltering()
               .AddSorting()
               .AddInMemorySubscriptions()
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
