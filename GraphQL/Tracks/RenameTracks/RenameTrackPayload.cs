using GraphQL.Common;
using GraphQL.Data.Entities;

namespace GraphQL.Tracks.RenameTracks;

public class RenameTrackPayload : TrackPayloadBase
{
    public RenameTrackPayload(Track track) : base(track) { }

    public RenameTrackPayload(IReadOnlyList<UserError> errors) : base(errors) { }
}
