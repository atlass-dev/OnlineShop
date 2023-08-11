using MediatR;

namespace OnlineShop.UseCases.Reviews.CreateReview;

/// <summary>
/// Creates review.
/// </summary>
public record CreateReviewCommand : IRequest<int>
{
    /// <summary>
    /// Product id.
    /// </summary>
    required public int ProductId { get; init; }

    /// <summary>
    /// Reviewer id.
    /// </summary>
    required public int ReviewerId { get; init; }

    /// <summary>
    /// Rating.
    /// </summary>
    required public int Rating { get; init; }

    /// <summary>
    /// Description.
    /// </summary>
    required public string Description { get; init; }
}
