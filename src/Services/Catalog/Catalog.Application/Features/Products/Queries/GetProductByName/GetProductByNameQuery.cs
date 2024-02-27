using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Features.Products.Queries.GetProductByName;

/// <summary>
/// Represents a request to get product by name.
/// </summary>
public class GetProductByNameQuery : IRequest<ProductResponse>
{
    /// <summary>
    /// Gets or sets a name.
    /// </summary>
    public string Name { get; set; }

    public GetProductByNameQuery(string name)
    {
        Name = name;
    }
}