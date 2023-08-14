using MediatR;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Abstractions.Database;

namespace OnlineShop.UseCases.Purchases.CreatePurchase;

/// <summary>
/// Handler for <see cref="CreatePurchaseCommand"/>.
/// </summary>
internal class CreatePurchaseCommandHandler : IRequestHandler<CreatePurchaseCommand, int>
{
    private readonly IAppDbContext dbContext;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreatePurchaseCommandHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    /// <inheritdoc/>
    public async Task<int> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
    {
        var purchase = new Purchase
        {
            ProductId = request.ProductId,
            Amount = request.Amount,
            PurchaserId = request.PurchaserId,
        };

        await dbContext.Purchases.AddAsync(purchase, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return purchase.Id;
    }
}
