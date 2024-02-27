using AutoMapper;
using Catalog.Application.Features.Photos.Commands.CreatePhoto;
using Catalog.Application.Features.Products.Commands.CreateProduct;
using Catalog.Application.Features.Products.Commands.UpdateProduct;
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

        CreateMap<Photo, PhotoResponse>().ReverseMap();
        CreateMap<Photo, CreatePhotoCommand>().ReverseMap();

        CreateMap<Category, CategoryResponse>().ReverseMap();
        CreateMap<Brand, BrandResponse>().ReverseMap();
    }
}