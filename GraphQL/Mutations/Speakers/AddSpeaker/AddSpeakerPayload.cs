using GraphQL.Data;

namespace GraphQL.Mutations.Speakers.AddSpeaker;

public class AddSpeakerPayload
{
    public AddSpeakerPayload(Speaker speaker)
    {
        Speaker = speaker;
    }

    public Speaker Speaker { get; }
}
