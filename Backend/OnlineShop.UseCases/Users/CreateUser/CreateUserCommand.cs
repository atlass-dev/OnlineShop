using MediatR;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.UseCases.Users.CreateUser;

/// <summary>
/// Creates user.
/// </summary>
public record CreateUserCommand : IRequest<int>
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
    [EmailAddress]
    [DataType(DataType.EmailAddress)]
    required public string Email { get; init; }

    /// <summary>
    /// Password.
    /// </summary>
    [DataType(DataType.Password)]
    required public string Password { get; init; }
}
