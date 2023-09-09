using GraphQL.Data;

namespace GraphQL.Presentation;

public class Query
{
    public IQueryable<Speaker> GetSpeakers([Service] ApplicationDbContext context) =>
        context.Speakers;
}
