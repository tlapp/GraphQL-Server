using GraphQL.Common;
using GraphQL.Data.Entities;

namespace GraphQL.Attendees.RegisterAttendees;

public class RegisterAttendeePayload : AttendeePayloadBase
{
    public RegisterAttendeePayload(Attendee attendee) : base(attendee) { }

    public RegisterAttendeePayload(UserError error) : base(new[] { error }) { }
}
