using OnlineShop.Domain.Entities;

namespace OnlineShop.UseCases.Shared.Users.Dto;

/// <inheritdoc cref="User"/>.
public record UserDto
{
    /// <summary>
    /// Id.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Email.
    /// </summary>
    public string Email { get; init; } = string.Empty;

    /// <summary>
    /// First name.
    /// </summary>
    public string FirstName { get; init; } = string.Empty;

    /// <summary>
    /// Last name.
    /// </summary>
    public string LastName { get; set; } = string.Empty;
}
