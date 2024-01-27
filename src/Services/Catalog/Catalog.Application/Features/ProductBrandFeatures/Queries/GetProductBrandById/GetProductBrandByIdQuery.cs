using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Features.ProductBrandFeatures.Queries.GetProductBrandById;

/// <summary>
/// Represents a request to get product brand by identifier.
/// </summary>
public class GetProductBrandByIdQuery : IRequest<ProductBrandResponse>
{
    /// <summary>
    /// Gets or sets an identifier.
    /// </summary>
    public string Id { get; set; }

    public GetProductBrandByIdQuery(string id)
    {
        Id = id;
    }
}