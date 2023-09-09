using System.ComponentModel.DataAnnotations;

namespace GraphQL.Data.Entities;

public class Track : BaseEntity
{
    [Required]
    [StringLength(200)]
    public string? Name { get; set; }

    public ICollection<Session> Sessions { get; set; } =
        new List<Session>();
}
