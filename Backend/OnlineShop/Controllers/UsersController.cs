using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.UseCases.Shared.Users.Dto;
using OnlineShop.UseCases.Users.CreateUser;

namespace OnlineShop.Controllers;

/// <summary>
/// Users controller.
/// </summary>
[ApiController]
[Route("api/users")]
public class UsersController : Controller
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public UsersController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Creates user.
    /// </summary>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>User information.</returns>
    [HttpPost]
    public async Task<UserDto> Create(CreateUserCommand command, CancellationToken cancellationToken)
        => await mediator.Send(command, cancellationToken);
}
