using GraphQL.Common;
using GraphQL.Data.Entities;

namespace GraphQL.Speakers.AddSpeakers;

public class AddSpeakerPayload : SpeakerPayloadBase
{
    public AddSpeakerPayload(Speaker speaker)
        : base(speaker)
    {
    }

    public AddSpeakerPayload(IReadOnlyList<UserError> errors)
        : base(errors)
    {
    }
}
