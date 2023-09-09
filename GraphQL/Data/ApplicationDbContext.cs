using GraphQL.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GraphQL.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Session> Sessions { get; set; } = default!;

    public DbSet<Track> Tracks { get; set; } = default!;

    public DbSet<Speaker> Speakers { get; set; } = default!;

    public DbSet<Attendee> Attendees { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
