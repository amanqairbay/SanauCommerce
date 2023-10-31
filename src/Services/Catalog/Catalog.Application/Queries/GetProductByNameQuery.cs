using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries;

/// <summary>
/// Represents a request to get product by name.
/// </summary>
public class GetProductByNameQuery : IRequest<IReadOnlyList<ProductResponse>>
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