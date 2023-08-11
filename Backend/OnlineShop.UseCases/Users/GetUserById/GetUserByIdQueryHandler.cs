using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Infrastructure.Abstractions.Database;
using OnlineShop.Infrastructure.Common.Exceptions;
using OnlineShop.UseCases.Shared.Users.Dto;

namespace OnlineShop.UseCases.Users.GetUserById;

/// <summary>
/// Handler for <see cref="GetUserByIdQuery"/>.
/// </summary>
public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IAppDbContext dbContext;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetUserByIdQueryHandler(IAppDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

        if (user == null)
        {
            throw new NotFoundException("User wasn't found.");
        }

        return mapper.Map<UserDto>(user);
    }
}
