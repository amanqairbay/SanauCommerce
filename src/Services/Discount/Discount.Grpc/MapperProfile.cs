using AutoMapper;
using Discount.Grpc.Entities;
using Discount.Grpc.Protos;

namespace Discount.Grpc;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Coupon, CouponModel>().ReverseMap();
    }
}