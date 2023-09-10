﻿using GraphQL.Data.Entities;
using GraphQL.Data;
using GraphQL.DataLoader;
using GraphQL.Extensions;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Types;

public class TrackType : ObjectType<Track>
{
    protected override void Configure(IObjectTypeDescriptor<Track> descriptor)
    {
        descriptor
            .ImplementsNode()
            .IdField(t => t.Id)
            .ResolveNode((ctx, id) =>
                ctx.DataLoader<TrackByIdDataLoader>().LoadAsync(id, ctx.RequestAborted));

        descriptor
            .Field(t => t.Sessions)
            .ResolveWith<TrackResolvers>(t => t.GetSessionsAsync(default!, default!, default!, default))
            .UseDbContext<ApplicationDbContext>()
            .UsePaging<NonNullType<SessionType>>()
            .Name("sessions");

        descriptor
            .Field(t => t.Name)
            .UseUpperCase();
    }

    private class TrackResolvers
    {
        public async Task<IEnumerable<Session>> GetSessionsAsync(
            Track track,
            [ScopedService] ApplicationDbContext dbContext,
            SessionByIdDataLoader sessionById,
            CancellationToken cancellationToken)
        {
            int[] sessionIds = await dbContext.Sessions
                .Where(s => s.Id == track.Id)
                .Select(s => s.Id)
                .ToArrayAsync();

            return await sessionById.LoadAsync(sessionIds, cancellationToken);
        }
    }
}