using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;

namespace Catalog.Application.Helpers;

/// <summary>
/// Represents a product image url resolver.
/// </summary>
public class ProductUrlResolver : IValueResolver<Product, ProductResponse, string>
{
    private readonly IConfiguration _configuration;

    public ProductUrlResolver(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Implementors use source object to provide a destination object.
    /// </summary>
    /// <param name="source">Source object.</param>
    /// <param name="destination">Destination object, if exists.</param>
    /// <param name="destMember">Destination member.</param>
    /// <param name="context">The context of the mapping.</param>
    /// <returns>Result, typically build from the source resolution result.</returns>
    public string Resolve(Product source, ProductResponse destination, string destMember, ResolutionContext context)
    {
        // if (!string.IsNullOrEmpty(source.n))
        // {
        //     return _configuration["ApiUrl"] + source.ImageUrl;
        // }

        return null!;
    }
}