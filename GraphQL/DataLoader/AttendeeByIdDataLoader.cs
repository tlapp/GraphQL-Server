using GraphQL.Data;
using GraphQL.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.DataLoader;

public class AttendeeByIdDataLoader : BatchDataLoader<int, Attendee>
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
    
    public AttendeeByIdDataLoader(
        IBatchScheduler batchScheduler,
        IDbContextFactory<ApplicationDbContext> contextFactory)
        : base(batchScheduler)
    {
        _contextFactory = contextFactory ?? 
            throw new ArgumentNullException(nameof(contextFactory));
    }

    protected override async Task<IReadOnlyDictionary<int, Attendee>> LoadBatchAsync(
        IReadOnlyList<int> keys,
        CancellationToken cancellationToken)
    {
        await using ApplicationDbContext context = 
            _contextFactory.CreateDbContext();

        return await context.Attendees
            .Where(w => keys.Contains(w.Id))
            .ToDictionaryAsync(t => t.Id, cancellationToken);
    }
}
