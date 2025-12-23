using System.ComponentModel.DataAnnotations;

namespace OptiMark.API.DTO;

public class RegisterDto
{
    
    [Microsoft.Build.Framework.Required]
    public string FullName { get; set; } = string.Empty;
    
    [Microsoft.Build.Framework.Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Microsoft.Build.Framework.Required]
    [MinLength(6)]
    public string Password { get; set; } = string.Empty;

    [Microsoft.Build.Framework.Required]
    [Compare("Password")]
    public string ConfirmPassword { get; set; } = string.Empty;

    // 🔽 Selected Role (from dropdown)
    [Microsoft.Build.Framework.Required]
    public string RoleId { get; set; } = string.Empty;

    // 🔽 Selected Company (from dropdown)
    [Microsoft.Build.Framework.Required]
    public int CompanyId { get; set; }
}