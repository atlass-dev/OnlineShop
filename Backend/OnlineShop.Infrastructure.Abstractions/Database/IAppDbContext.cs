using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entities;

namespace OnlineShop.Infrastructure.Abstractions.Database;

/// <summary>
/// Database context.
/// </summary>
public interface IAppDbContext : IDbContextWithSets, IDisposable
{
    /// <summary>
    /// Users.
    /// </summary>
    DbSet<User> Users { get; }

    /// <summary>
    /// Products.
    /// </summary>
    DbSet<Product> Products { get; }

    /// <summary>
    /// Purchases.
    /// </summary>
    DbSet<Purchase> Purchases { get; }

    /// <summary>
    /// Reviews.
    /// </summary>
    DbSet<Review> Reviews { get; }
}
