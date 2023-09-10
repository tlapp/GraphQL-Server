using GraphQL.Data;
using GraphQL.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace GraphQL.DataLoader;

public class TrackByIdDataLoader : BatchDataLoader<int, Track>
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

    public TrackByIdDataLoader(
        IBatchScheduler batchScheduler,
        IDbContextFactory<ApplicationDbContext> contextFactory)
        : base(batchScheduler)
    {
        _contextFactory = contextFactory ??
            throw new ArgumentNullException(nameof(contextFactory));
    }

    protected override async Task<IReadOnlyDictionary<int, Track>> LoadBatchAsync(
        IReadOnlyList<int> keys,
        CancellationToken cancellationToken)
    {
        await using ApplicationDbContext context =
            _contextFactory.CreateDbContext();

        return await context.Tracks
            .Where(w => keys.Contains(w.Id))
            .ToDictionaryAsync(t => t.Id, cancellationToken);
    }
}
