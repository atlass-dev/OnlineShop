using AutoMapper;
using OnlineShop.Domain.Entities;
using OnlineShop.UseCases.Shared.Reviews.Dto;

namespace OnlineShop.UseCases.Reviews;

/// <summary>
/// Reviews mapping profile.
/// </summary>
internal class ReviewsMappingProfile : Profile
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public ReviewsMappingProfile()
    {
        CreateMap<Review, ReviewDto>();
    }
}
