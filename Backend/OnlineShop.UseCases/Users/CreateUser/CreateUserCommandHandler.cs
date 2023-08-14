using MediatR;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Common.Exceptions;

namespace OnlineShop.UseCases.Users.CreateUser;

/// <summary>
/// Handler for <see cref="CreateUserCommand"/>.
/// </summary>
internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly UserManager<User> userManager;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateUserCommandHandler(UserManager<User> userManager)
    {
        this.userManager = userManager;
    }

    /// <inheritdoc/>
    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            UserName = request.Email
        };

        var result = await userManager.CreateAsync(user, request.Password);
        
        if (!result.Succeeded)
        {
            throw new DomainException($"Failed to create user with email {request.Email}");
        }

        return user.Id;
    }
}
