using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.Categories.Querie.GetCategoryList;

/// <summary>
/// Represents a handler to get categories.
/// </summary>
public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, IReadOnlyList<CategoryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public GetCategoriesHandler(IMapper mapper, IRepositoryManager repository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    /// <summary>
    /// Handles a request.
    /// </summary>
    /// <param name="request">Request to get categories.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the categories.
    /// </returns>
    public async Task<IReadOnlyList<CategoryResponse>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _repository.Category.GetAllAsync();
        var categoriesResponse = _mapper.Map<IReadOnlyList<CategoryResponse>>(categories.ToList());

        return categoriesResponse;
    }
}