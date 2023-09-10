namespace GraphQL.Tracks.RenameTracks;

public record RenameTrackInput([ID(nameof(TracksMutations))] int Id, string Name);
