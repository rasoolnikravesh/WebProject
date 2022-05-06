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
    public DbSet<Models.Permission>? Permissions { get; set; }
    public DbSet<Models.Controller>? Controllers { get; set; }
    public DbSet<Models.Action>? Actions { get; set; }
    public DbSet<Models.Group>? Groups { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //**************************************************
        builder.Entity<Models.ApplicationUser>()
            .HasMany<Models.Post>(u => u.Posts)
            .WithOne(p => p.User)
            .HasForeignKey(f => f.UserId);

        //**************************************************
        builder.Entity<Models.Post>()
            .HasIndex(p => p.Title)
            .IsUnique();
        //**************************************************

        builder.Entity<Models.Category>()
            .HasMany(category => category.Posts)
            .WithOne(post => post.Category)
            .OnDelete(DeleteBehavior.SetNull).HasForeignKey(f => f.CategoryId);
        //**************************************************
        builder.Entity<Models.Permission>()
            .HasIndex(i => i.Route)
            .IsUnique();

        builder.Entity<Models.Permission>()
            .HasIndex(i => i.Name)
            .IsUnique();

        builder.Entity<Models.Permission>()
            .HasMany<Models.ApplicationRole>(p => p.Roles)
            .WithMany(a => a.Permissions);

        builder.Entity<Models.Permission>()
            .HasMany<Models.ApplicationUser>(p => p.Users)
            .WithMany(u => u.Permissions);

        //**************************************************
        builder.Entity<Models.Controller>()
            .HasMany<Models.Action>(c => c.actions)
            .WithOne(p => p.Controller)
            .HasForeignKey(f => f.ControllerId);

        builder.Entity<Models.Controller>()
            .HasIndex(c => c.Name)
            .IsUnique();

        //**************************************************
        builder.Entity<Models.Action>()
            .HasOne<Models.Permission>(a => a.Permission)
            .WithOne(p => p.Action)
            .HasForeignKey<Models.Action>(p => p.PermissionId);

        builder.Entity<Models.Action>()
            .HasIndex(a => a.Name)
            .IsUnique();

        //**************************************************

        builder.Entity<Models.Group>()
            .HasMany<Models.Permission>(g => g.Permissions)
            .WithMany(p => p.Groups);

        builder.Entity<Models.Group>()
            .HasMany<Models.ApplicationRole>(g => g.Roles)
            .WithMany(r => r.Groups);

        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
