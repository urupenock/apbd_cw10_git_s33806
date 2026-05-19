using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.Entities;

public class Component
{
    [Key]
    [MaxLength(10)]
    public string Code { get; set; } = null!;
    [Required]
    [MaxLength(300)]
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int ComponentManufacturersId { get; set; }
    [ForeignKey(nameof(ComponentManufacturersId))]
    public virtual ComponentManufacturer ComponentManufacturer { get; set; } = null!;
    public int ComponentTypesId { get; set; }
    [ForeignKey(nameof(ComponentTypesId))]
    public virtual ComponentType ComponentType { get; set; } = null!;
    public virtual ICollection<PcComponent> PcComponents { get; set; } = new List<PcComponent>();
}