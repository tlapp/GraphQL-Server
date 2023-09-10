using GraphQL.Common;
using GraphQL.Data.Entities;
using GraphQL.DataLoader;

namespace GraphQL.Attendees.CheckInAttendees;

public class CheckInAttendeePayload : AttendeePayloadBase
{
    private int? _sessionId;

    public CheckInAttendeePayload(Attendee attendee, int sessionId) : base(attendee) 
    {
        _sessionId = sessionId;
    }

    public CheckInAttendeePayload(UserError error) : base(new[] { error }) { }

    public async Task<Session?> GetSessionAsync(
        SessionByIdDataLoader sessionById,
        CancellationToken cancellationToken)
    {
        if (_sessionId.HasValue)
        {
            return await sessionById.LoadAsync(
                _sessionId.Value,
                cancellationToken);
        }

        return null;
    }
}
