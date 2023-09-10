using GraphQL.Extensions;
using GraphQL.Data;
using Microsoft.EntityFrameworkCore;
using GraphQL.Data.Entities;
using GraphQL.DataLoader;

namespace GraphQL.Speakers;

[ExtendObjectType("Query")]
public class SpeakerQueries
{
    [UseApplicationDbContext]
    public Task<List<Speaker>> GetSpeakers([ScopedService] ApplicationDbContext context) =>
        context.Speakers.ToListAsync();

    public Task<Speaker> GetSpeakerAsync(
        [ID(nameof(Speaker))] int id,
        SpeakerByIdDataLoader dataLoader,
        CancellationToken cancellationToken) =>
        dataLoader.LoadAsync(id, cancellationToken);
}
