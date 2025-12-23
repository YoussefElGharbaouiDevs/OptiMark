using Microsoft.AspNetCore.Identity;
using OptiMark.DAL.Models;

namespace OptiMark.API.Config.Seeds;

public static class RoleSeeder
{
    public static async Task SeedAsync(RoleManager<AppRole> roleManager)
    {
        string[] roles = { "Admin", "Marketer", "User" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new AppRole
                {
                    Name = role
                });
            }
        }
    }
}