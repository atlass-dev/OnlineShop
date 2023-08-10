using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Abstractions.Database;

namespace OnlineShop.Infrastructure.DataAccess;

/// <inheritdoc cref="IAppDbContext"/>
public class AppDbContext : IdentityDbContext<User, AppIdentityRole, int>, IAppDbContext
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="options"></param>
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    /// <inheritdoc/>
    public DbSet<Product> Products { get; private set; }

    /// <inheritdoc/>
    public DbSet<Purchase> Purchases { get; private set; }

    /// <inheritdoc/>
    public DbSet<Review> Reviews { get; private set; }

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        RestrictCascadeDelete(builder);
        SetupProducts(builder.Entity<Product>());
    }

    private void RestrictCascadeDelete(ModelBuilder builder)
    {
        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }

    private void SetupProducts(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Price)
            .HasColumnType("decimal(18,4)");
    }
}
