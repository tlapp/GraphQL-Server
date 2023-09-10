using GraphQL.Common;
using GraphQL.Data.Entities;

namespace GraphQL.Tracks;

public class TrackPayloadBase : Payload
{
    public Track? Track { get; }
    
    public TrackPayloadBase(Track track)
    {
        Track = track;
    }

    public TrackPayloadBase(IReadOnlyList<UserError> errors) : base(errors) { }
}
