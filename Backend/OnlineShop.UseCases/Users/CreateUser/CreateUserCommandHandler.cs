using MediatR;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Abstractions.Database;

namespace OnlineShop.UseCases.Users.CreateUser;

/// <summary>
/// Handler for <see cref="CreateUserCommand"/>.
/// </summary>
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IAppDbContext dbContext;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateUserCommandHandler(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    /// <inheritdoc/>
    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email
        };

        await dbContext.Users.AddAsync(user, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
