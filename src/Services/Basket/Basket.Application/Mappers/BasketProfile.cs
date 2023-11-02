using AutoMapper;
using Basket.Application.Responses;
using Basket.Core.Entities;

namespace Basket.Application.Mappers;

/// <summary>
/// Provides a named configuration for maps. Naming conventions become scoped per profile.
/// </summary>
public class BasketProfile : Profile
{
    public BasketProfile()
    {
        CreateMap<ShoppingCart, ShoppingCartResponse>().ReverseMap();
        CreateMap<ShoppingCartItem, ShoppingCartItemResponse>().ReverseMap();
    }
}