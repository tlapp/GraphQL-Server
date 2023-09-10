namespace GraphQL.Tracks.RenameTracks;

public record RenameTrackInput([ID(nameof(TrackMutations))] int Id, string Name);
