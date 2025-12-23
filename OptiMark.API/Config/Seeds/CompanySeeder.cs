using OptiMark.DAL;
using OptiMark.DAL.Models;

namespace OptiMark.API.Config.Seeds;

public static class CompanySeeder
{
    public static async Task SeedAsync(OptiMarkDbContext context)
    {
        if (context.Companies.Any())
            return;

        var companies = new List<Company>
        {
            new Company
            {
                CompanyName = "GrowthLab",
                ProfileDetails = "Data-driven digital marketing agency"
            },
            new Company
            {
                CompanyName = "Marketify",
                ProfileDetails = "Performance marketing and SEO specialists"
            },
            new Company
            {
                CompanyName = "BrandSpark",
                ProfileDetails = "Branding and creative campaigns"
            },
            new Company
            {
                CompanyName = "AdVision",
                ProfileDetails = "Paid ads and analytics experts"
            },
            new Company
            {
                CompanyName = "NextGen Marketing",
                ProfileDetails = "Full-stack growth marketing solutions"
            }
        };

        await context.Companies.AddRangeAsync(companies);
        await context.SaveChangesAsync();
    }
}