using GraphQL.Common;
using GraphQL.Data.Entities;

namespace GraphQL.Sessions.AddSessions;

public class AddSessionPayload : Payload
{
    public AddSessionPayload(Session session)
    {
        Session = session;
    }

    public AddSessionPayload(UserError error)
        : base(new[] { error })
    {
    }

    public Session? Session { get; init; }
}