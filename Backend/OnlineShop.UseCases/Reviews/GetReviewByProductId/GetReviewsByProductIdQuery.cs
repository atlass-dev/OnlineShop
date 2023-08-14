using MediatR;
using OnlineShop.UseCases.Shared.Reviews.Dto;

namespace OnlineShop.UseCases.Reviews.GetReviewByProductId;

/// <summary>
/// Gets reviews of specific product.
/// </summary>
/// <param name="ProductId">Product id.</param>
public record GetReviewsByProductIdQuery(int ProductId) : IRequest<IReadOnlyCollection<ReviewDto>>;
