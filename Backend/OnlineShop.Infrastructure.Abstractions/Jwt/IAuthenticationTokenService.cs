using System.Security.Claims;

namespace OnlineShop.Infrastructure.Abstractions.Jwt;

/// <summary>
/// Provides methods for interacting with JWT token.
/// </summary>
public interface IAuthenticationTokenService
{
    /// <summary>
    /// Generates JWT token based on claims.
    /// </summary>
    /// <param name="claims">Claims.</param>
    /// <param name="expirationTime">Expiration time.</param>
    /// <returns>JWT token.</returns>
    string GenerateToken(IEnumerable<Claim> claims, TimeSpan expirationTime);

    /// <summary>
    /// Gets claims from JWT token.
    /// </summary>
    /// <param name="token">JWT token.</param>
    /// <returns>Collection of claims.</returns>
    IEnumerable<Claim> GetClaimsFromToken(string token);
}
