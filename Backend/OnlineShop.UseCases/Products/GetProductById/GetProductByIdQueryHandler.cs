using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Infrastructure.Abstractions.Database;
using OnlineShop.Infrastructure.Common.Exceptions;
using OnlineShop.UseCases.Shared.Products.Dto;

namespace OnlineShop.UseCases.Products.GetProductById;

/// <summary>
/// Handler for <see cref="GetProductByIdQuery"/>.
/// </summary>
public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
{
    private readonly IAppDbContext dbContext;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetProductByIdQueryHandler(IAppDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (product == null)
        {
            throw new NotFoundException("Product wasn't found.");
        }

        return mapper.Map<ProductDto>(product);
    }
}
