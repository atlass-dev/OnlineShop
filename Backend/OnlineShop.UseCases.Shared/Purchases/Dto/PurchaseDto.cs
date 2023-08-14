using OnlineShop.Domain.Entities;

namespace OnlineShop.UseCases.Shared.Purchases.Dto;

/// <inheritdoc cref="Purchase"/>
public record PurchaseDto
{
    /// <summary>
    /// Purchase's id.
    /// </summary>
    required public int Id { get; init; }

    /// <summary>
    /// Amount of product.
    /// </summary>
    required public int Amount { get; init; }

    /// <summary>
    /// Product's id.
    /// </summary>
    required public int ProductId { get; init; }

    /// <summary>
    /// Purchaser's id.
    /// </summary>
    required public int PurchaserId { get; init; }
}
