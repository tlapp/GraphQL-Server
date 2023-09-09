using GraphQL.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Data.Configurations
{
    public class SessionAttendeeConfiguration : IEntityTypeConfiguration<SessionAttendee>
    {
        public void Configure(EntityTypeBuilder<SessionAttendee> builder)
        {
            builder.HasKey(ca => new { ca.SessionId, ca.AttendeeId });
        }
    }
}