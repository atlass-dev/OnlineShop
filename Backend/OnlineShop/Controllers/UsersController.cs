using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.UseCases.Shared.Users.Dto;
using OnlineShop.UseCases.Users.CreateUser;
using OnlineShop.UseCases.Users.GetUserById;

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
    /// Gets user by id.
    /// </summary>
    /// <param name="request">Request.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>User information.</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<UserDto> GetById(int id, CancellationToken cancellationToken)
        => await mediator.Send(new GetUserByIdQuery(id), cancellationToken);
}
