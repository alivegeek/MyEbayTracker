using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ItemOfInterest> ItemsOfInterest { get; set; }
    public DbSet<UserItemInterest> UserItemInterests { get; set; }
    public DbSet<Listing> Listings { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Additional configurations can go here, for example, configuring the many-to-many relationship
        builder.Entity<UserItemInterest>()
            .HasKey(ui => new { ui.UserId, ui.ItemOfInterestId });

        builder.Entity<UserItemInterest>()
            .HasOne(ui => ui.User)
            .WithMany(u => u.UserItemInterests)
            .HasForeignKey(ui => ui.UserId);

        builder.Entity<UserItemInterest>()
            .HasOne(ui => ui.ItemOfInterest)
            .WithMany(i => i.UserItemInterests)
            .HasForeignKey(ui => ui.ItemOfInterestId);
    }
}
