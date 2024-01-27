using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Features.ProductImageFeatures.Queries.GetProductImageByName;

/// <summary>
/// Represents a request to get product image by name.
/// </summary>
public class GetProductImageByNameQuery : IRequest<ProductImageResponse>
{
    /// <summary>
    /// Gets or sets a product image name.
    /// </summary>
    public string Name { get; set; } = String.Empty;

    public GetProductImageByNameQuery(string name)
    {
        Name = name;
    }
}