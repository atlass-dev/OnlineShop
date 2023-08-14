namespace OnlineShop.UseCases.Users.AuthenticateUser;

/// <summary>
/// JWT token representation.
/// </summary>
public record TokenDto
{
    /// <summary>
    /// Token.
    /// </summary>
    required public string Token { get; init; }

    /// <summary>
    /// Token expiration in seconds.
    /// </summary>
    required public long ExpriresIn { get; init; }
}
