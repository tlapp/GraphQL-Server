using GraphQL.Data.Entities;

namespace GraphQL.Attendees.CheckInAttendees;

public record CheckInAttendeeInput(
    [ID(nameof(Session))] int SessionId,
    [ID(nameof(Attendee))] int AttendeeId);
