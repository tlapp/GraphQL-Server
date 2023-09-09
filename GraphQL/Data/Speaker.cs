using System.ComponentModel.DataAnnotations;

namespace GraphQL.Data;

public class Speaker
{
    public int Id { get; set; }
    [Required]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;
    [StringLength(400)]
    public string Bio { get; set; } = string.Empty;
    [StringLength(1000)]
    public virtual string WebSite { get; set; } = string.Empty;
}
