using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Features.ProductTypeFeatures.Queries.GetProductTypeById;

/// <summary>
/// Represents a request to get product by identifier.
/// </summary>
public class GetProductTypeByIdQuery : IRequest<ProductTypeResponse>
{
    /// <summary>
    /// Gets or sets an identifier.
    /// </summary>
    public string Id { get; set; }

    public GetProductTypeByIdQuery(string id)
    {
        Id = id;
    }
}