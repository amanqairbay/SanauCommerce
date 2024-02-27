using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Features.Products.Queries.GetProductList;

/// <summary>
/// Represents a get products query.
/// </summary>
public class GetProductsQuery : IRequest<IReadOnlyList<ProductResponse>>
{

}