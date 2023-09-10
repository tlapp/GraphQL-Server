using GraphQL.Common;
using GraphQL.Data.Entities;

namespace GraphQL.Sessions;

public class SessionPayloadBase : Payload
{
    public Session? Session { get; }

    protected SessionPayloadBase(Session session)
    {
        Session = session;
    }

    protected SessionPayloadBase(IReadOnlyList<UserError> errors)
        : base(errors)
    {
    }
}
