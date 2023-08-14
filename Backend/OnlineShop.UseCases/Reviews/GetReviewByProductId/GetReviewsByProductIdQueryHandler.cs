using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Infrastructure.Abstractions.Database;
using OnlineShop.Infrastructure.Common.Exceptions;
using OnlineShop.UseCases.Shared.Reviews.Dto;

namespace OnlineShop.UseCases.Reviews.GetReviewByProductId;

/// <summary>
/// Handler for <see cref="GetReviewsByProductIdQuery"/>.
/// </summary>
internal class GetReviewsByProductIdQueryHandler : IRequestHandler<GetReviewsByProductIdQuery, IReadOnlyCollection<ReviewDto>>
{
    private readonly IAppDbContext dbContext;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetReviewsByProductIdQueryHandler(IAppDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<IReadOnlyCollection<ReviewDto>> Handle(GetReviewsByProductIdQuery request, CancellationToken cancellationToken)
    {
        var reviews = await dbContext.Reviews.Where(r => r.ProductId == request.ProductId).ToListAsync(cancellationToken);

        if (reviews is null)
        {
            throw new NotFoundException($"Product with id {request.ProductId} was not found.");
        }

        return mapper.Map<IReadOnlyCollection<ReviewDto>>(reviews);
    }
}
