using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries;

/// <summary>
/// Represents a request to get product by identifier.
/// </summary>
public class GetProductByIdQuery : IRequest<ProductResponse>
{
    /// <summary>
    /// Gets or sets an identifier.
    /// </summary>
    public string Id { get; set; }

    public GetProductByIdQuery(string id)
    {
        Id = id;
    }
}