using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OptiMark.DAL.Models;

namespace OptiMark.DAL;

public class OptiMarkDbContext: IdentityDbContext<AppUser, AppRole, string>
{
    public OptiMarkDbContext(DbContextOptions<OptiMarkDbContext> options)
        : base(options)
    {
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<Channel> Channels { get; set; }
    public DbSet<PerformanceData> PerformanceData { get; set; }
    public DbSet<KPI> KPIs { get; set; }
    public DbSet<Report> Reports { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Campaign>().HasKey(e => e.Id);
        builder.Entity<Company>().HasKey(e => e.Id);
        builder.Entity<Report>().HasKey(e => e.Id);
        builder.Entity<Channel>().HasKey(e => e.Id);
        builder.Entity<KPI>().HasKey(e => e.Id);
        builder.Entity<PerformanceData>().HasKey(e => e.Id);
        
        // Optionally rename Identity tables
        builder.Entity<AppUser>().ToTable("Users");
        builder.Entity<AppRole>().ToTable("Roles");
        builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
        builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
        builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
        builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
        
        builder.Entity<Report>()
            .HasOne(r => r.Company)
            .WithMany(c => c.Reports)
            .HasForeignKey(r => r.CompanyId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Report>()
            .HasOne(r => r.Campaign)
            .WithMany(c => c.Reports)
            .HasForeignKey(r => r.CampaignId)
            .OnDelete(DeleteBehavior.NoAction);

    }
}