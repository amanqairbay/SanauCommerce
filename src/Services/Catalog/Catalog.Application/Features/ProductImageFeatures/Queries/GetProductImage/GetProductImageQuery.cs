using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Features.ProductImageFeatures.Queries.GetProductImage;

/// <summary>
/// Represents a request to get product image by name.
/// </summary>
public class GetProductImageQuery : IRequest<ProductImageResponse>
{
    /// <summary>
    /// Gets or sets a name.
    /// </summary>
    public string Name { get; set; } = String.Empty;

    public GetProductImageQuery(string name)
    {
        Name = name;
    }
}