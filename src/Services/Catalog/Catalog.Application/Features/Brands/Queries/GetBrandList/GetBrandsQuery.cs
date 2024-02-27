using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Features.Brands.Queries.GetBrandList;

/// <summary>
/// Represents a get product brands query.
/// </summary>
public class GetBrandsQuery : IRequest<IReadOnlyList<BrandResponse>>
{
        
}