using GraphQL.Data;
using GraphQL.Data.Entities;
using GraphQL.DataLoader;
using GraphQL.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Types;

public class AttendeeType : ObjectType<Attendee>
{
    protected override void Configure(IObjectTypeDescriptor<Attendee> descriptor)
    {
        descriptor
            .ImplementsNode()
            .IdField(t => t.Id)
            .ResolveNode((ctx, id) => 
                ctx.DataLoader<AttendeeByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));

        descriptor
            .Field(t => t.SessionsAttendees)
            .ResolveWith<AttendeeResolvers>(t => t.GetSessionsAsync(default!, default!, default!, default))
            .UseDbContext<ApplicationDbContext>()
            .Name("sessions");
    }

    private class AttendeeResolvers
    {
        public async Task<IEnumerable<Session>> GetSessionsAsync(
            Attendee attendee,
            [ScopedService] ApplicationDbContext context,
            SessionByIdDataLoader sessionById,
            CancellationToken cancellationToken)
        {
            int[] speakerIds = await context.Attendees
                .Where(w => w.Id == attendee.Id)
                .Include(a => a.SessionsAttendees)
                .SelectMany(a => a.SessionsAttendees.Select(s => s.SessionId))
                .ToArrayAsync();

            return await sessionById.LoadAsync(speakerIds, cancellationToken);
        }
    }
}
