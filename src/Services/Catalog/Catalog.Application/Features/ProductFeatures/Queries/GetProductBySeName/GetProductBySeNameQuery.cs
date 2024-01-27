using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Features.ProductFeatures.Queries.GetProductBySeName;

/// <summary>
/// Represents a request to get product by search engine friendly page name.
/// </summary>
public class GetProductBySeNameQuery : IRequest<ProductResponse>
{
    /// <summary>
    /// Gets or sets a search engine friendly page name.
    /// </summary>
    public string SeName { get; set; }

    public GetProductBySeNameQuery(string seName)
    {
        SeName = seName;
    }
}