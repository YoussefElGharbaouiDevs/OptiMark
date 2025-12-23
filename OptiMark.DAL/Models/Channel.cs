using System.ComponentModel.DataAnnotations;
using OptiMark.DAL.Common;

namespace OptiMark.DAL.Models;

public class Channel : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string ChannelName { get; set; }

    // Navigation properties
    public ICollection<PerformanceData> PerformanceData { get; set; }
    public ICollection<KPI> KPIs { get; set; }
}