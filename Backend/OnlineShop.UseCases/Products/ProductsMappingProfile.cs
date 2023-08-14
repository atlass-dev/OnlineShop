using AutoMapper;
using OnlineShop.Domain.Entities;
using OnlineShop.UseCases.Shared.Products.Dto;

namespace OnlineShop.UseCases.Products;

/// <summary>
/// Products mapping profile.
/// </summary>
internal class ProductsMappingProfile : Profile
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public ProductsMappingProfile()
    {
        CreateMap<Product, ProductDto>();
    }
}
