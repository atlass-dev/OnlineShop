namespace OnlineShop.Domain.Entities;

/// <summary>
/// Represents a purchase of product.
/// </summary>
public class Purchase
{
    /// <summary>
    /// Purchase's id.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Amount of product.
    /// </summary>
    required public int Amount { get; set; }

    /// <summary>
    /// Product's id.
    /// </summary>
    required public int ProductId { get; set; }

    /// <summary>
    /// Product.
    /// </summary>
    public Product? Product { get; set; }

    /// <summary>
    /// Purchaser's id.
    /// </summary>
    required public int PurchaserId { get; set; }

    /// <summary>
    /// Purchaser.
    /// </summary>
    public User? Purchaser { get; set; }
}
