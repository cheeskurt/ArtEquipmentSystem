using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Areas.Identity.Data;
using WebApplication3.Models;

namespace WebApplication3.Areas.Identity.Data;

public class ArtEquipmentContext : IdentityDbContext<User>
{

    public ArtEquipmentContext(DbContextOptions<ArtEquipmentContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

public DbSet<WebApplication3.Models.Item> Item { get; set; } = default!;

public DbSet<WebApplication3.Models.ItemIssue> ItemIssue { get; set; } = default!;

public DbSet<WebApplication3.Models.Student> Student { get; set; } = default!;

public DbSet<WebApplication3.Models.Issue> Issue { get; set; } = default!;

public DbSet<WebApplication3.Models.Subject> Subject { get; set; } = default!;

public DbSet<WebApplication3.Models.Stock> Stock { get; set; } = default!;
}
