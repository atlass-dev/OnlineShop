using OnlineShop.UseCases.Users.CreateUser;

namespace OnlineShop.Infrastructure.DependencyInjection;

/// <summary>
/// Register AutoMapper dependencies.
/// </summary>
internal static class AutoMapperModule
{
    /// <summary>
    /// Registers dependencies,
    /// </summary>
    public static void Register(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(CreateUserCommand).Assembly);
    }
}
