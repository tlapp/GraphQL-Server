using HotChocolate.Data.Filters;
using GraphQL.Data.Entities;

namespace GraphQL.Types;

public class SessionFilterInputType : FilterInputType<Session>
{
    protected override void Configure(IFilterInputTypeDescriptor<Session> descriptor)
    {
        descriptor.Ignore(t => t.Id);
        descriptor.Ignore(t => t.TrackId);
    }
}