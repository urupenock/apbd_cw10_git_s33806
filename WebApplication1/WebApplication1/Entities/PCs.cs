using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Entities;

public class PCs
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;
    public double Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }
    public virtual ICollection<PcComponents> PcComponents { get; set; } = new List<PcComponents>();
}