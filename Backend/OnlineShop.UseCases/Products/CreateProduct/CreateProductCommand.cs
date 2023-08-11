using MediatR;
using OnlineShop.Domain.Enums;

namespace OnlineShop.UseCases.Products.CreateProduct;

/// <summary>
/// Creates product.
/// </summary>
public record CreateProductCommand : IRequest<int>
{
    /// <summary>
    /// Product's name.
    /// </summary>
    required public string Name { get; init; }

    /// <summary>
    /// Product's description.
    /// </summary>
    required public string Description { get; init; }

    /// <summary>
    /// Product's price.
    /// </summary>
    required public decimal Price { get; init; }

    /// <summary>
    /// Category.
    /// </summary>
    required public Category Category { get; init; }

    /// <summary>
    /// Seller's id.
    /// </summary>
    required public int SellerId { get; init; }
}
