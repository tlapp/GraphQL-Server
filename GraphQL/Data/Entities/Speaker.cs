using System.ComponentModel.DataAnnotations;

namespace GraphQL.Data.Entities;

public class Speaker : BaseEntity
{
    [Required]
    [StringLength(200)]
    public string? Name { get; set; }
    [StringLength(400)]
    public string? Bio { get; set; }
    [StringLength(1000)]
    public virtual string? WebSite { get; set; }

    public ICollection<SessionSpeaker> SessionSpeakers { get; set; } =
        new List<SessionSpeaker>();
}
