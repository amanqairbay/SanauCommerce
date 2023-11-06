using AutoMapper;
using Discount.Core.Entities;
using Discount.Application.Responses;
using Discount.Application.Commands;

namespace Discount.Application.Mappers;

/// <summary>
/// Provides a named configuration for maps. Naming conventions become scoped per profile.
/// </summary>
public class DiscountProfile : Profile
{
    public DiscountProfile()
    {
        CreateMap<Coupon, CouponResponse>().ReverseMap();
        CreateMap<Coupon, CreateDiscountCommand>().ReverseMap();
        CreateMap<Coupon, UpdateDiscountCommand>().ReverseMap();
    }
}