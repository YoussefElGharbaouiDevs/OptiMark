using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OptiMark.DAL.Common;

namespace OptiMark.DAL.Models;

public class KPI : BaseEntity
{
    [Required]
    public int CampaignId { get; set; }

    [Required]
    public int ChannelId { get; set; }

    [Column(TypeName = "date")]
    public DateTime Date { get; set; }

    [Column(TypeName = "decimal(10,4)")]
    public decimal ROI { get; set; }

    [Column(TypeName = "decimal(10,4)")]
    public decimal CPA { get; set; }

    [Column(TypeName = "decimal(10,4)")]
    public decimal CTR { get; set; }

    [Column(TypeName = "decimal(10,4)")]
    public decimal CPC { get; set; }

    // Navigation properties
    [ForeignKey(nameof(CampaignId))]
    public Campaign Campaign { get; set; }

    [ForeignKey(nameof(ChannelId))]
    public Channel Channel { get; set; }
}