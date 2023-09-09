using GraphQL.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Data.Configurations
{
    public class SessionSpeakerConfiguration : IEntityTypeConfiguration<SessionSpeaker>
    {
        public void Configure(EntityTypeBuilder<SessionSpeaker> builder)
        {
            builder.HasKey(s => new { s.SessionId, s.SpeakerId });
        }
    }
}