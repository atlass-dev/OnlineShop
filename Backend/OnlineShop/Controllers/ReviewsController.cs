using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.UseCases.Reviews.CreateReview;
using OnlineShop.UseCases.Reviews.GetReviewByProductId;
using OnlineShop.UseCases.Shared.Reviews.Dto;

namespace OnlineShop.Controllers;

/// <summary>
/// Reviews controller.
/// </summary>
[Route("api/reviews")]
[ApiController]
public class ReviewsController : ControllerBase
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public ReviewsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Gets product's reviews.
    /// </summary>
    /// <param name="productId">Product id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Product's reviews.</returns>
    [HttpGet("product/{productId:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IEnumerable<ReviewDto>> GetReviewsByProductId(int productId, CancellationToken cancellationToken)
        => await mediator.Send(new GetReviewsByProductIdQuery(productId), cancellationToken);

    /// <summary>
    /// Creates product's review.
    /// </summary>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancelation token.</param>
    /// <returns>Id of created review.</returns>
    [HttpPost]
    [ProducesResponseType(200)]
    public async Task<int> CreateReview(CreateReviewCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command, cancellationToken);
}
