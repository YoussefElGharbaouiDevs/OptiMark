using System.ComponentModel.DataAnnotations;
using OptiMark.DAL.Common;

namespace OptiMark.DAL.Models;

public class Company : BaseEntity
{
    [Required]
    [MaxLength(200)]
    public string CompanyName { get; set; }

    public string? ProfileDetails { get; set; }

    // Navigation property
    public ICollection<Campaign> Campaigns { get; set; }
    public ICollection<Report> Reports { get; set; }
}