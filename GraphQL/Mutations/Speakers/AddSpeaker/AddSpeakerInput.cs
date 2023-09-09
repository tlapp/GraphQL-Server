namespace GraphQL.Mutations.Speakers.AddSpeaker;

public record AddSpeakerInput(
    string Name,
    string Bio,
    string WebSite);
