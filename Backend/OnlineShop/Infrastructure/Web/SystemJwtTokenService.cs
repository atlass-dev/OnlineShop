using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Infrastructure.Abstractions.Jwt;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OnlineShop.Infrastructure.Web;

/// <inheritdoc cref="IAuthenticationTokenService"/>
public class SystemJwtTokenService : IAuthenticationTokenService
{
    private readonly TokenValidationParameters tokenValidationParameters;

    /// <summary>
    /// Constructor.
    /// </summary>
    public SystemJwtTokenService(IOptionsMonitor<JwtBearerOptions> jwtOptionsMonitor)
    {
        tokenValidationParameters = jwtOptionsMonitor.Get(JwtBearerDefaults.AuthenticationScheme)
            .TokenValidationParameters.Clone();
    }

    /// <inheritdoc/>
    public string GenerateToken(IEnumerable<Claim> claims, TimeSpan expirationTime)
    {
        var jwtSecurityToken = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.Add(expirationTime),
            issuer: tokenValidationParameters.ValidIssuer,
            audience: tokenValidationParameters.ValidAudience,
            signingCredentials:
                new SigningCredentials(tokenValidationParameters.IssuerSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }

    /// <inheritdoc/>
    public IEnumerable<Claim> GetClaimsFromToken(string token)
    {
        var principal = new JwtSecurityTokenHandler()
            .ValidateToken(token, tokenValidationParameters, out SecurityToken _);
        return principal.Claims;
    }
}
