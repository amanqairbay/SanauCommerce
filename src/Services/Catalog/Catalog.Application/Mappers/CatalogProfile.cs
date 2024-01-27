using AutoMapper;
using Catalog.Application.Features.ProductFeatures.Commands.UpdateProduct;
using Catalog.Application.Features.ProductImageFeatures.Commands.CreateProductImage;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.RequestFeatures;

namespace Catalog.Application.Mappers;

/// <summary>
/// Provides a named configuration for maps. Naming conventions become scoped per profile.
/// </summary>
public sealed class CatalogProfile : Profile
{
    public CatalogProfile()
    {
        CreateMap<Product, ProductResponse>().ReverseMap();
        CreateMap<Pagination<Product>, Pagination<ProductResponse>>();
        CreateMap<Product, CreateProductCommand>().ReverseMap();
        CreateMap<Product, UpdateProductCommand>().ReverseMap();

        CreateMap<ProductImage, ProductImageResponse>().ReverseMap();
        CreateMap<ProductImage, CreateProductImageCommand>().ReverseMap();

        CreateMap<ProductType, ProductTypeResponse>().ReverseMap();
        CreateMap<ProductBrand, ProductBrandResponse>().ReverseMap();
    }
}