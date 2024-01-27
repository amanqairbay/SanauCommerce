using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Features.ProductImageFeatures.Queries.GetProductImage;

/// <summary>
/// Represents a request to get product image by name.
/// </summary>
public class GetProductImageQuery : IRequest<PhotoResponse>
{
    /// <summary>
    /// Gets or sets a product identifier.
    /// </summary>
    public string ProductImageId { get; set; } = String.Empty;

    public GetProductImageQuery(string productImageId)
    {
        ProductImageId = productImageId;
    }
}