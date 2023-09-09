using GraphQL.Extensions;
using GraphQL.Data;
using Microsoft.EntityFrameworkCore;
using GraphQL.Data.Entities;
using GraphQL.DataLoader;

namespace GraphQL.Presentation;

public class Query
{
    [UseApplicationDbContext]
    public Task<List<Speaker>> GetSpeakers([ScopedService] ApplicationDbContext context) =>
        context.Speakers.ToListAsync();

    public Task<Speaker> GetSpeakerAsync(
        int id,
        SpeakerByIdDataLoader dataLoader,
        CancellationToken cancellationToken) => 
        dataLoader.LoadAsync(id, cancellationToken);
}
