using GraphQL.Common;
using GraphQL.Data;
using GraphQL.Data.Entities;
using GraphQL.DataLoader;
using GraphQL.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Sessions.ScheduleSessions;

public class ScheduleSessionPayload : SessionPayloadBase
{
    public ScheduleSessionPayload(Session session) : base(session) { }

    public ScheduleSessionPayload(UserError error) : base(new[] { error }) { }

    public async Task<Track?> GetTrackAsync(
        TrackByIdDataLoader trackById,
        CancellationToken cancellationToken)
    {
        if (Session is null)
        {
            return null;
        }

        return await trackById.LoadAsync(Session.Id, cancellationToken);
    }

    [UseApplicationDbContext]
    public async Task<IEnumerable<Speaker>?> GetSpeakersAsync(
        [ScopedService] ApplicationDbContext context,
        SpeakerByIdDataLoader speakerById,
        CancellationToken cancellationToken)
    {
        if (Session is null)
        {
            return null;
        }

        int[] speakerIds = await context.Sessions
            .Where(w => w.Id == Session.Id)
            .Include(s => s.SessionSpeakers)
            .SelectMany(s => s.SessionSpeakers.Select(t => t.SpeakerId))
            .ToArrayAsync();

        return await speakerById.LoadAsync(speakerIds, cancellationToken);
    }
}
