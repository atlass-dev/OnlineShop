using MediatR;

namespace OnlineShop.UseCases.Purchases.CreatePurchase;

/// <summary>
/// Creates purchase.
/// </summary>
public record CreatePurchaseCommand : IRequest<int>
{
    /// <summary>
    /// Product id.
    /// </summary>
    required public int ProductId { get; init; }

    /// <summary>
    /// Purchaser id.
    /// </summary>
    required public int PurchaserId { get; init; }

    /// <summary>
    /// Amount.
    /// </summary>
    required public int Amount { get; init; }
}
