using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries;

/// <summary>
/// Represents a get products query.
/// </summary>
public class GetProductsQuery : IRequest<IReadOnlyList<ProductResponse>>
{

}