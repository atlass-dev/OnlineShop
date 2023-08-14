using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.UseCases.Purchases.CreatePurchase;
using OnlineShop.UseCases.Purchases.GetPurchasesByUserId;
using OnlineShop.UseCases.Shared.Purchases.Dto;

namespace OnlineShop.Controllers;

/// <summary>
/// Purchases controller.
/// </summary>
[ApiController]
[Authorize]
[Route("api/purchases")]
public class PurchasesController : ControllerBase
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public PurchasesController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Gets purchases of specific user.
    /// </summary>
    /// <param name="userId">User id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Purchases of user.</returns>
    [HttpGet("user/{userId:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IEnumerable<PurchaseDto>> GetPurchasesByUserId(int userId, CancellationToken cancellationToken)
        => await mediator.Send(new GetPurchasesByUserIdQuery(userId), cancellationToken);

    /// <summary>
    /// Creates purchase.
    /// </summary>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Id of created purchase.</returns>
    [HttpPost]
    [ProducesResponseType(200)]
    public async Task<int> CreatePurchase(CreatePurchaseCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command, cancellationToken);
}
