using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.Categories.Queries.GetCategoryById;

/// <summary>
/// Represents a handler to get category by identifier.
/// </summary>
public class GetProductTypeByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryResponse>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public GetProductTypeByIdHandler(IMapper mapper, IRepositoryManager repository)
	{
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
	}

    /// <summary>
    /// Handles a request.
    /// </summary>
    /// <param name="request">Request to get category by identifier.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the category.
    /// </returns>
    /// <exception cref="NotFoundException">Throw if the category doesn't exists in database.</exception>
    public async Task<CategoryResponse> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _repository.Category.GetByIdAsync(request.Id) 
            ?? throw new NotFoundException($"The product type with {request.Id} doesn't exist in the database.");

        var categoryResponse = _mapper.Map<CategoryResponse>(category);

        return categoryResponse;
    }
}