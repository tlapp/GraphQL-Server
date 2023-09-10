﻿using GraphQL.Data;
using GraphQL.Data.Entities;
using GraphQL.Extensions;
using GraphQL.Tracks.AddTracks;
using GraphQL.Tracks.RenameTracks;

namespace GraphQL.Tracks;

[ExtendObjectType("Mutation")]
public class TracksMutations
{
    [UseApplicationDbContext]
    public async Task<AddTrackPayload> AddTrackAsync(
        AddTrackInput input,
        [ScopedService] ApplicationDbContext context,
        CancellationToken cancellationToken)
    {
        var track = new Track { Name = input.Name };
        context.Tracks.Add(track);

        await context.SaveChangesAsync(cancellationToken);

        return new AddTrackPayload(track);
    }

    [UseApplicationDbContext]
    public async Task<RenameTrackPayload> RenameTrackAsync(
        RenameTrackInput input,
        [ScopedService] ApplicationDbContext context,
        CancellationToken cancellationToken)
    {
        Track track = await context.Tracks.FindAsync(new object?[] { input.Id }, cancellationToken: cancellationToken);
        track.Name = input.Name;

        await context.SaveChangesAsync(cancellationToken);

        return new RenameTrackPayload(track);
    }
}
