using GraphQL.Data;
using GraphQL.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.DataLoader;

public class SpeakerByIdDataLoader : BatchDataLoader<int, Speaker>
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

    public SpeakerByIdDataLoader(
        IBatchScheduler batchScheduler,
        IDbContextFactory<ApplicationDbContext> contextFactory)
        : base(batchScheduler)
    {
        _contextFactory = contextFactory ?? 
            throw new ArgumentNullException(nameof(contextFactory));
    }

    protected override async Task<IReadOnlyDictionary<int, Speaker>> LoadBatchAsync(
        IReadOnlyList<int> keys,
        CancellationToken cancellationToken)
    {
        await using ApplicationDbContext dbContext =
            _contextFactory.CreateDbContext();

        return await dbContext.Speakers
            .Where(w => keys.Contains(w.Id))
            .ToDictionaryAsync(t => t.Id, cancellationToken);
    }
}
