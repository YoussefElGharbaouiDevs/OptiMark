using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OptiMark.DAL.Common;

namespace OptiMark.DAL.Models;

public class PerformanceData : BaseEntity
{
    [Required] public int CampaignId { get; set; }

    [Required] public int ChannelId { get; set; }

    [Column(TypeName = "date")] public DateTime Date { get; set; }

    public int Impressions { get; set; }
    public int Clicks { get; set; }

    [Column(TypeName = "decimal(18,2)")] public decimal BudgetSpent { get; set; }

    public int Conversions { get; set; }

    [Column(TypeName = "decimal(18,2)")] public decimal Revenue { get; set; }

    // Navigation properties
    [ForeignKey(nameof(CampaignId))] public Campaign Campaign { get; set; }

    [ForeignKey(nameof(ChannelId))] public Channel Channel { get; set; }
}