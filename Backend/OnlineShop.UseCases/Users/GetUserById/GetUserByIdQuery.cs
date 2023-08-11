using MediatR;
using OnlineShop.UseCases.Shared.Users.Dto;

namespace OnlineShop.UseCases.Users.GetUserById;

/// <summary>
/// Finds user by id.
/// </summary>
/// <param name="Id">User's id.</param>
public record GetUserByIdQuery(int Id) : IRequest<UserDto>;
