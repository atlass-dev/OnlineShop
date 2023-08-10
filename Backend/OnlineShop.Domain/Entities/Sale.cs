namespace OnlineShop.Domain.Entities;

/// <summary>
/// Represents a sale of product.
/// </summary>
public class Sale
{
    /// <summary>
    /// Sale's id.
    /// </summary>
    public int Id { get; set; }

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
}
