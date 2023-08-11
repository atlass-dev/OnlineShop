using OnlineShop.UseCases.Users.CreateUser;

namespace OnlineShop.Infrastructure.DependencyInjection;

/// <summary>
/// Registers MediatR dependencies.
/// </summary>
internal static class MediatRModule
{
    /// <summary>
    /// Registers dependencies.
    /// </summary>
    public static void Register(IServiceCollection services)
    {
        var useCasesAssembly = typeof(CreateUserCommand).Assembly;

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(useCasesAssembly));
    }
}
