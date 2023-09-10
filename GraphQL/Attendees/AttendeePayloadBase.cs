using GraphQL.Common;
using GraphQL.Data.Entities;

namespace GraphQL.Attendees;

public class AttendeePayloadBase : Payload
{
    protected AttendeePayloadBase(Attendee attendee) { }

    protected AttendeePayloadBase(IReadOnlyList<UserError> errors) : base(errors) { }

    public Attendee? Attendee { get; }
}
