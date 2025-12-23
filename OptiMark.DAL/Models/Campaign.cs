using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OptiMark.DAL.Common;

namespace OptiMark.DAL.Models;

public class Campaign : BaseEntity
{
    [Required]
    public int CompanyId { get; set; }

    [Required]
    [MaxLength(200)]
    public string CampaignName { get; set; }

    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime EndDate { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Budget { get; set; }

    // Navigation properties
    [ForeignKey(nameof(CompanyId))]
    public Company Company { get; set; }

    public ICollection<PerformanceData> PerformanceData { get; set; }
    public ICollection<KPI> KPIs { get; set; }
    public ICollection<Report> Reports { get; set; }
}