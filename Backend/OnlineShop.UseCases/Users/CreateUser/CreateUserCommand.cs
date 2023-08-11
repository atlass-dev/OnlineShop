using MediatR;
using OnlineShop.UseCases.Shared.Users.Dto;

namespace OnlineShop.UseCases.Users.CreateUser;

/// <summary>
/// Creates user.
/// </summary>
public record CreateUserCommand : IRequest<UserDto>
{
    /// <summary>
    /// First name.
    /// </summary>
    required public string FirstName { get; init; }

    /// <summary>
    /// Last name.
    /// </summary>
    required public string LastName { get; init; }

    /// <summary>
    /// Email.
    /// </summary>
    required public string Email { get; init; }
}
