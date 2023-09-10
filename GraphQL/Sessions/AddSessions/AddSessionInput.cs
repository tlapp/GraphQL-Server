using GraphQL.Data.Entities;

namespace GraphQL.Sessions.AddSessions;

public record AddSessionInput(
    string Title,
    string? Abstract,
    [ID(nameof(Speaker))] IReadOnlyList<int> SpeakerIds);
