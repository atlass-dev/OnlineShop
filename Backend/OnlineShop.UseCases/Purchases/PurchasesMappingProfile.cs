using AutoMapper;
using OnlineShop.Domain.Entities;
using OnlineShop.UseCases.Shared.Purchases.Dto;

namespace OnlineShop.UseCases.Purchases;

/// <summary>
/// Purchases mapping profile.
/// </summary>
internal class PurchasesMappingProfile : Profile
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public PurchasesMappingProfile()
    {
        CreateMap<Purchase, PurchaseDto>();
    }
}
