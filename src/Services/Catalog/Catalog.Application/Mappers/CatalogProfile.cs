using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.RequestFeatures;

namespace Catalog.Application.Mappers;

/// <summary>
/// Provides a named configuration for maps. Naming conventions become scoped per profile.
/// </summary>
public class CatalogProfile : Profile
{
    public CatalogProfile()
    {
        CreateMap<Product, ProductResponse>().ReverseMap();
            
        CreateMap<Pagination<Product>, Pagination<ProductResponse>>().ReverseMap();
        CreateMap<Product, CreateProductCommand>().ReverseMap();
        CreateMap<Product, UpdateProductCommand>().ReverseMap();
    }
}