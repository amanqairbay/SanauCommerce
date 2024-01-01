using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries;

/// <summary>
/// Represents a request to get product by category.
/// </summary>
public class GetProductByTypeQuery : IRequest<IReadOnlyList<ProductResponse>>
{
    /// <summary>
    /// Gets or sets a category.
    /// </summary>
    public string Type { get; set; }

    public GetProductByTypeQuery(string type)
    {
        Type = type;
    }
}