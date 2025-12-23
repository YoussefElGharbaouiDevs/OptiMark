using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OptiMark.DAL.Common;

namespace OptiMark.DAL.Models;

public class Report : BaseEntity
{

    [Required]
    public int CampaignId { get; set; }

    [Required]
    public int CompanyId { get; set; }

    [Required]
    public ReportType ReportType { get; set; }

    public DateTime GeneratedDate { get; set; }

    // Navigation properties
    [ForeignKey(nameof(CampaignId))]
    public Campaign Campaign { get; set; }

    [ForeignKey(nameof(CompanyId))]
    public Company Company { get; set; }
}