using GraphQL.Data;
using GraphQL.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.DataLoader;

public class SessionByIdDataLoader : BatchDataLoader<int, Session>
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

    public SessionByIdDataLoader(
        IBatchScheduler batchScheduler,
        IDbContextFactory<ApplicationDbContext> contextFactory)
        : base(batchScheduler)
    {
        _contextFactory = contextFactory ??
            throw new ArgumentNullException(nameof(contextFactory));
    }

    protected override async Task<IReadOnlyDictionary<int, Session>> LoadBatchAsync(
        IReadOnlyList<int> keys,
        CancellationToken cancellationToken)
    {
        await using ApplicationDbContext dbContext = 
            _contextFactory.CreateDbContext();

        return await dbContext.Sessions
            .Where(w => keys.Contains(w.Id))
            .ToDictionaryAsync(t => t.Id, cancellationToken);
    }
}
