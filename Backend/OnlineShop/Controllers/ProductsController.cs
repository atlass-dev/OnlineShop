using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.UseCases.Products.CreateProduct;
using OnlineShop.UseCases.Products.GetProductById;
using OnlineShop.UseCases.Shared.Products.Dto;

namespace OnlineShop.Controllers;

/// <summary>
/// Products controller.
/// </summary>
[ApiController]
[Route("api/products")]
public class ProductsController : Controller
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public ProductsController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Creates product.
    /// </summary>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Product id.</returns>
    [HttpPost]
    [Authorize]
    public async Task<int> CreateProduct(CreateProductCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command, cancellationToken);

    /// <summary>
    /// Finds product by id.
    /// </summary>
    /// <param name="id">Product's id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Product's information.</returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ProductDto> GetById(int id, CancellationToken cancellationToken)
        => await mediator.Send(new GetProductByIdQuery(id), cancellationToken);
}
