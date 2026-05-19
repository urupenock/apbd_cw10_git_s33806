using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication1.Entities;
public class PcComponents
{
    public int PcId { get; set; }
    [ForeignKey(nameof(PcId))]
    public virtual PCs Pc { get; set; } = null!;
    public string ComponentCode { get; set; } = null!;
    [ForeignKey(nameof(ComponentCode))]
    public virtual Components Component { get; set; } = null!;
    public int Amount { get; set; }
}