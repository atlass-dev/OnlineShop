using MediatR;
using OnlineShop.UseCases.Shared.Products.Dto;

namespace OnlineShop.UseCases.Products.GetProductById;

/// <summary>
/// Gets product by id.
/// </summary>
/// <param name="Id">Product's id.</param>
public record GetProductByIdQuery(int Id) : IRequest<ProductDto>;
