using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GraphQL;
using GraphQL.Attendees;
using GraphQL.Data;
using GraphQL.Sessions;
using GraphQL.Speakers;
using GraphQL.Tracks;
using GraphQL.Types;
using HotChocolate;
using HotChocolate.Execution;
using Snapshooter.Xunit;
using Xunit;

namespace GraphQL.Tests;

public class AttendeeTests
{
    //[Fact]
    //public async Task Attendee_Schema_Changed()
    //{
    //    // arrange
    //    // act
    //    ISchema schema = await new ServiceCollection()
    //        .AddPooledDbContextFactory<ApplicationDbContext>(
    //            options => options.UseInMemoryDatabase("Data Source=App_data\\conferences.db"))
    //        .AddGraphQL()
    //        .AddQueryType(d => d.Name("Query"))
    //            .AddTypeExtension<AttendeeQueries>()
    //        .AddMutationType(d => d.Name("Mutation"))
    //            .AddTypeExtension<AttendeeMutations>()
    //        .AddType<AttendeeType>()
    //        .AddType<SessionType>()
    //        .AddType<SpeakerType>()
    //        .AddType<TrackType>()
    //        .EnableRelaySupport()
    //        .BuildSchemaAsync();

    //    // assert
    //    schema.Print().MatchSnapshot();
    //}

    //[Fact]
    //public async Task RegisterAttendee()
    //{
    //    // arrange
    //    IRequestExecutor executor = await new ServiceCollection()
    //        .AddPooledDbContextFactory<ApplicationDbContext>(
    //            options => options.UseInMemoryDatabase("Data Source=conferences.db"))
    //        .AddGraphQL()
    //        .AddQueryType(d => d.Name("Query"))
    //            .AddTypeExtension<AttendeeQueries>()
    //        .AddMutationType(d => d.Name("Mutation"))
    //            .AddTypeExtension<AttendeeMutations>()
    //        .AddType<AttendeeType>()
    //        .AddType<SessionType>()
    //        .AddType<SpeakerType>()
    //        .AddType<TrackType>()
    //        .EnableRelaySupport()
    //        .BuildRequestExecutorAsync();

    //    // act
    //    IExecutionResult result = await executor.ExecuteAsync(@"
    //    mutation RegisterAttendee {
    //        registerAttendee(
    //            input: {
    //                emailAddress: ""michael@chillicream.com""
    //                    firstName: ""michael""
    //                    lastName: ""staib""
    //                    userName: ""michael3""
    //                })
    //        {
    //            attendee {
    //                id
    //            }
    //        }
    //    }");

    //    // assert
    //    result.ToJson().MatchSnapshot();
    //}
}