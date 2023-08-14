using AutoMapper;
using OnlineShop.Domain.Entities;
using OnlineShop.UseCases.Shared.Users.Dto;

namespace OnlineShop.UseCases.Users;

/// <summary>
/// Users mapping profile.
/// </summary>
internal class UsersMappingProfile : Profile
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public UsersMappingProfile()
    {
        CreateMap<User, UserDto>();
    }
}
