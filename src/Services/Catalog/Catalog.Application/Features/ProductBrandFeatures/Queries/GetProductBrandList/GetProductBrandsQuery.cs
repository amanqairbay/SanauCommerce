using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Features.ProductBrandFeatures.Queries.GetProductBrandList;

/// <summary>
/// Represents a get product brands query.
/// </summary>
public class GetProductBrandsQuery : IRequest<IReadOnlyList<ProductBrandResponse>>
{
        
}