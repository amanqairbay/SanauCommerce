using AutoMapper;
using Discount.Core.Entities;
using Discount.GrpcServer.Protos;

namespace Discount.GrpcServer.Application.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Coupon, CouponModel>().ReverseMap();
    }
}