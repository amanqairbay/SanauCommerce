using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Features.Products.Queries.GetProductByCategory;

/// <summary>
/// Represents a request to get product by category.
/// </summary>
public class GetProductByCategoryQuery : IRequest<IReadOnlyList<ProductResponse>>
{
    /// <summary>
    /// Gets or sets a category identifier.
    /// </summary>
    public string CategoryId { get; set; }

    public GetProductByCategoryQuery(string categoryId)
    {
        CategoryId = categoryId;
    }
}