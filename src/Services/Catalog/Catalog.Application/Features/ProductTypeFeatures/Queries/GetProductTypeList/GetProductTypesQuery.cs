using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Features.ProductTypeFeatures.Querie.GetProductTypeList;

/// <summary>
/// Represents a get product types query.
/// </summary>
public class GetProductTypesQuery : IRequest<IReadOnlyList<ProductTypeResponse>>
{
        
}