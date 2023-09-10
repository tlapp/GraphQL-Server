﻿using GraphQL.Data;
using GraphQL.Data.Entities;
using GraphQL.Extensions;
using GraphQL.Speakers.AddSpeakers;

namespace GraphQL.Speakers;

[ExtendObjectType(Name = "Mutation")]
public class SpeakerMutations
{
    [UseApplicationDbContext]
    public async Task<AddSpeakerPayload> AddSpeakerAsync(
        AddSpeakerInput input,
        [ScopedService] ApplicationDbContext context)
    {
        var speaker = new Speaker
        {
            Name = input.Name,
            Bio = input.Bio,
            WebSite = input.WebSite
        };

        context.Speakers.Add(speaker);
        await context.SaveChangesAsync();

        return new AddSpeakerPayload(speaker);
    }
}