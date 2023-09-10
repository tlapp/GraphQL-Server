using GraphQL.Common;
using GraphQL.Data.Entities;

namespace GraphQL.Sessions.AddSessions;

public class AddSessionPayload : SessionPayloadBase
{
    public AddSessionPayload(UserError error) : base(new[] { error }) { }

    public AddSessionPayload(Session session) : base(session) { }

    public AddSessionPayload(IReadOnlyList<UserError> errors) : base(errors) { }
}
