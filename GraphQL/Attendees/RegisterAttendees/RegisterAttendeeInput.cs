namespace GraphQL.Attendees.RegisterAttendees;

public record RegisterAttendeeInput(
    string FirstName,
    string LastName,
    string UserName,
    string EmailAddress);
