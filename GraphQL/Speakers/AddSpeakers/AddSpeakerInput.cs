namespace GraphQL.Speakers.AddSpeakers;

public record AddSpeakerInput(
    string Name,
    string? Bio,
    string? WebSite);
