using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Entities;

public class ComponentManufacturers
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    public string Abbreviation { get; set; } = null!;
    [Required]
    [MaxLength(300)]
    public string FullName { get; set; } = null!;
    public DateTime FoundationDate { get; set; }
    public virtual ICollection<Components> Components { get; set; } = new List<Components>();
}