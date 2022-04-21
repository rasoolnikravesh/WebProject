using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Data;

internal class DatabaseContext : IdentityDbContext<Models.ApplicationUser, Models.ApplicationRole, Guid>
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public DbSet<Models.Post>? Posts { get; set; }
    public DbSet<Models.Category>? Categories { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityUserRole<Guid>>().HasKey(p => new { p.RoleId, p.UserId });

        builder.Entity<Models.ApplicationUser>().HasMany<Models.Post>(u => u.Posts).WithOne(p => p.User)
            .HasForeignKey(f => f.UserId);

        builder.Entity<Models.Category>().HasMany<Models.Post>(category => category.Posts).WithMany(post => post.Categories);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
