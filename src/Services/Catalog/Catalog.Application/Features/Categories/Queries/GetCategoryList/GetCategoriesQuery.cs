using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Features.Categories.Querie.GetCategoryList;

/// <summary>
/// Represents a get list of category query.
/// </summary>
public class GetCategoriesQuery : IRequest<IReadOnlyList<CategoryResponse>>
{
        
}