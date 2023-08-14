using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Enums;
using OnlineShop.UseCases.Shared.Purchases.Dto;
using OnlineShop.UseCases.Shared.Reviews.Dto;

namespace OnlineShop.UseCases.Shared.Products.Dto;

/// <inheritdoc cref="Product"/>
public record ProductDto
{
    /// <summary>
    /// Product id.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Product name.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Product description.
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// Product price.
    /// </summary>
    public decimal Price { get; init; }

    /// <summary>
    /// Product rating.
    /// </summary>
    public double Rating { get; init; }

    /// <summary>
    /// Product category.
    /// </summary>
    public Category Category { get; init; }

    /// <summary>
    /// Seller id.
    /// </summary>
    public int SellerId { get; init; }

    /// <summary>
    /// Created at.
    /// </summary>
    public DateTime CreatedAt { get; init; }
}
