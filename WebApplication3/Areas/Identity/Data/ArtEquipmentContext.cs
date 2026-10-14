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

        builder.Entity<Issue>()
            .HasOne(i => i.Student)
            .WithMany(s => s.Issues)
            .HasForeignKey(i => i.StudentID)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Issue>()
            .HasOne(i => i.Subject)
            .WithMany(s => s.Issues)
            .HasForeignKey(i => i.SubjectID)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<ItemIssue>()
            .HasOne(iti => iti.Stock)
            .WithMany(s => s.ItemIssues)
            .HasForeignKey(iti => iti.StockID)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<ItemIssue>()
            .HasOne(ii => ii.Issue)
            .WithMany(i => i.ItemIssues)
            .HasForeignKey(ii => ii.IssueID)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Stock>()
            .HasOne(s => s.Item)
            .WithMany(i => i.Stocks)
            .HasForeignKey(s => s.ItemID)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<ItemIssue>()
            .HasIndex(ii => ii.StockID)
            .IsUnique()
            .HasFilter("[DateReturned] IS NULL");

        builder.Entity<Stock>().HasIndex(s => s.StockTag).IsUnique();
        builder.Entity<Student>().HasIndex(s => s.Email).IsUnique();

    }

public DbSet<WebApplication3.Models.Item> Item { get; set; } = default!;

public DbSet<WebApplication3.Models.ItemIssue> ItemIssue { get; set; } = default!;

public DbSet<WebApplication3.Models.Student> Student { get; set; } = default!;

public DbSet<WebApplication3.Models.Issue> Issue { get; set; } = default!;

public DbSet<WebApplication3.Models.Subject> Subject { get; set; } = default!;

public DbSet<WebApplication3.Models.Stock> Stock { get; set; } = default!;
}
