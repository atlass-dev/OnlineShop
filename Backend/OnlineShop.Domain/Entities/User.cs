using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Domain.Entities;

/// <summary>
/// Represents an user.
/// </summary>
public class User : IdentityUser<int>
{
    /// <summary>
    /// User's first name.
    /// </summary>
    required public string FirstName { get; init; }

    /// <summary>
    /// User's last name.
    /// </summary>
    required public string LastName { get; init; }

    /// <summary>
    /// Products.
    /// </summary>
    public IEnumerable<Product> Products { get; set; } = new List<Product>();

    /// <summary>
    /// Purchases.
    /// </summary>
    public IEnumerable<Purchase> Purchases { get; set; } = new List<Purchase>();

    /// <summary>
    /// Reviews.
    /// </summary>
    public IEnumerable<Review> Reviews { get; set; } = new List<Review>();
}
