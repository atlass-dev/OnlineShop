using MediatR;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Abstractions.Database;

namespace OnlineShop.UseCases.Products.CreateProduct;

/// Handler for <see cref="CreateProductCommand"/>.
internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IAppDbContext dbContext;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateProductCommandHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    /// <inheritdoc/>
    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Category = request.Category,
            Price = request.Price,
            SellerId = request.SellerId,
            CreatedAt = DateTime.UtcNow
        };

        await dbContext.Products.AddAsync(product, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return product.Id;
    }
}
