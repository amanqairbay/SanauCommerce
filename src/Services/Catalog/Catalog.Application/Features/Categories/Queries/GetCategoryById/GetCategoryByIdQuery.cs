using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Features.Categories.Queries.GetCategoryById;

/// <summary>
/// Represents a request to get product by identifier.
/// </summary>
public class GetCategoryByIdQuery : IRequest<CategoryResponse>
{
    /// <summary>
    /// Gets or sets an identifier.
    /// </summary>
    public string Id { get; set; }

    public GetCategoryByIdQuery(string id)
    {
        Id = id;
    }
}