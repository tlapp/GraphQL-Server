using GraphQL.Common;
using GraphQL.Data.Entities;

namespace GraphQL.Tracks.AddTracks;

public class AddTrackPayload : TrackPayloadBase
{
    public AddTrackPayload(Track track) : base(track) { }

    public AddTrackPayload(IReadOnlyList<UserError> errors) : base(errors) { }
}
