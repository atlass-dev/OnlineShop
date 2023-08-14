using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace OnlineShop.Infrastructure.Startup;

internal class JwtBearerOptionsSetup
{
    private readonly string secretKey;
    private readonly string issuer;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="issuer">JWT issuer.</param>
    /// <param name="secretKey">JWT secret key.</param>
    public JwtBearerOptionsSetup(string issuer, string secretKey)
    {
        this.issuer = issuer;
        this.secretKey = secretKey;
    }

    /// <summary>
    /// Setup JWT options.
    /// </summary>
    /// <param name="options">The options.</param>
    public void Setup(JwtBearerOptions options)
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
            ValidIssuer = issuer,
            ValidateLifetime = true,
            LifetimeValidator = ValidateTokenLifetime,
        };
    }

    private static bool ValidateTokenLifetime(DateTime? notBefore,
        DateTime? expires,
        SecurityToken securityToken,
        TokenValidationParameters validationParameters)
    {
        var clonedParameters = validationParameters.Clone();
        clonedParameters.LifetimeValidator = null;
        try
        {
            Validators.ValidateLifetime(notBefore, expires, securityToken, clonedParameters);
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }
}
