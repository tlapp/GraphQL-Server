using GraphQL.Data;
using GraphQL.Data.Entities;
using GraphQL.DataLoader;
using GraphQL.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Tracks;

[ExtendObjectType("Query")]
public class TrackQueries
{
    [UseApplicationDbContext]
    public async Task<IEnumerable<Track>> GetTracksAsync(
        [ScopedService] ApplicationDbContext context,
        CancellationToken cancellationToken) =>
        await context.Tracks.ToListAsync(cancellationToken);

    [UseApplicationDbContext]
    public Task<Track> GetTrackByNameAsync(
        string name,
        [ScopedService] ApplicationDbContext context,
        CancellationToken cancellationToken) =>
        context.Tracks.FirstAsync(t => t.Name == name);

    [UseApplicationDbContext]
    public async Task<IEnumerable<Track>> GetTracksByNamesAsync(
        string[] names,
        [ScopedService] ApplicationDbContext context,
        CancellationToken cancellationToken) =>
        await context.Tracks.Where(w => names.Contains(w.Name))
            .ToListAsync(cancellationToken);

    public Task<Track> GetTrackByIdAsync(
        [ID(nameof(Track))] int id,
        TrackByIdDataLoader trackById,
        CancellationToken cancellationToken) =>
        trackById.LoadAsync(id, cancellationToken);

    public async Task<IEnumerable<Track>> GetTracksByIdAsync(
        [ID(nameof(Track))] int[] ids,
        TrackByIdDataLoader trackById,
        CancellationToken cancellationToken) =>
        await trackById.LoadAsync(ids, cancellationToken);
}
