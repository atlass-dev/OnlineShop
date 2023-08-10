using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Entities;

/// <summary>
/// Represents a product's review.
/// </summary>
public class Review
{
    /// <summary>
    /// Review's id.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Product's id.
    /// </summary>
    required public int ProductId { get; set; }

    /// <summary>
    /// Product.
    /// </summary>
    public Product? Product { get; set; }

    /// <summary>
    /// Review's rating.
    /// </summary>
    [Required]
    required public int Rating { get; set; }

    /// <summary>
    /// Review's description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Reviewer's id.
    /// </summary>
    public int ReviewerId { get; set; }

    /// <summary>
    /// Reviewer.
    /// </summary>
    public User? Reviewer { get; set; }
}
