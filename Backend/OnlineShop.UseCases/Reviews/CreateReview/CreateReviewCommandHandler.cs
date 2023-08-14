using MediatR;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Abstractions.Database;

namespace OnlineShop.UseCases.Reviews.CreateReview;

/// <summary>
/// Handler for <see cref="CreateReviewCommand"/>.
/// </summary>
internal class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, int>
{
    private readonly IAppDbContext dbContext;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateReviewCommandHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    /// <inheritdoc/>
    public async Task<int> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var review = new Review
        {
            ProductId = request.ProductId,
            Rating = request.Rating,
            ReviewerId = request.ReviewerId,
            Description = request.Description
        };

        await dbContext.Reviews.AddAsync(review, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return review.Id;
    }
}
