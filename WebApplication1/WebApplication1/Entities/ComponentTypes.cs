using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entities;

public class ComponentTypes

{

    [Key]

    public int Id { get; set; }

    [Required]

    [MaxLength(30)]

    public string Abbreviation { get; set; } = null!;

    [Required]

    [MaxLength(150)]

    public string Name { get; set; } = null!;

    public virtual ICollection<Components> Components { get; set; } = new List<Components>();

}