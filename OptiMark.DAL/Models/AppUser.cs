
using Microsoft.AspNetCore.Identity;

namespace OptiMark.DAL.Models;

public class AppUser : IdentityUser
{
    public string FullName { get; set; }
    public int CompanyId { get; set; }

    // Navigation
    public Company Company { get; set; }
}