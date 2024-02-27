using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Features.Brands.Queries.GetBrandById;

/// <summary>
/// Represents a request to get product brand by identifier.
/// </summary>
public class GetBrandByIdQuery : IRequest<BrandResponse>
{
    /// <summary>
    /// Gets or sets an identifier.
    /// </summary>
    public string Id { get; set; }

    public GetBrandByIdQuery(string id)
    {
        Id = id;
    }
}