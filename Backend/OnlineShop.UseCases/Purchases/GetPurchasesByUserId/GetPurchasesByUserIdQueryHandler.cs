using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Infrastructure.Abstractions.Database;
using OnlineShop.Infrastructure.Common.Exceptions;
using OnlineShop.UseCases.Shared.Purchases.Dto;

namespace OnlineShop.UseCases.Purchases.GetPurchasesByUserId;

/// <summary>
/// Handler for <see cref="GetPurchasesByUserIdQuery"/>.
/// </summary>
internal class GetPurchasesByUserIdQueryHandler : IRequestHandler<GetPurchasesByUserIdQuery, IReadOnlyCollection<PurchaseDto>>
{
    private readonly IAppDbContext dbContext;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetPurchasesByUserIdQueryHandler(IAppDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<IReadOnlyCollection<PurchaseDto>> Handle(GetPurchasesByUserIdQuery request, CancellationToken cancellationToken)
    {
        var purchases = await dbContext.Purchases
            .Where(p => p.PurchaserId == request.UserId)
            .ToListAsync(cancellationToken);

        if (purchases is null)
        {
            throw new NotFoundException($"User with id {request.UserId} not found.");
        }

        return mapper.Map<IReadOnlyCollection<PurchaseDto>>(purchases);
    }
}
