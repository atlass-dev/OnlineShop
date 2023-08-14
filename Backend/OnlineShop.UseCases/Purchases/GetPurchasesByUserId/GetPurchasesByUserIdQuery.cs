using MediatR;
using OnlineShop.UseCases.Shared.Purchases.Dto;

namespace OnlineShop.UseCases.Purchases.GetPurchasesByUserId;

/// <summary>
/// Gets purchases by user id.
/// </summary>
/// <param name="UserId">User id.</param>
public record GetPurchasesByUserIdQuery(int UserId) : IRequest<IReadOnlyCollection<PurchaseDto>>;
