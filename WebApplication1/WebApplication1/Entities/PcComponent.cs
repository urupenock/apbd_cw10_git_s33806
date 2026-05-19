using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.Entities;
public class PcComponent
{
    public int PcId { get; set; }
    [ForeignKey(nameof(PcId))]
    public virtual Pc Pc { get; set; } = null!;
    public string ComponentCode { get; set; } = null!;
    [ForeignKey(nameof(ComponentCode))]
    public virtual Component Component { get; set; } = null!;
    public int Amount { get; set; }
}