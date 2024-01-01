using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Entities.Exceptions;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

/// <summary>
/// Represents a handler to get products category.
/// </summary>
public class GetProductsByTypeHandler(IRepositoryManager repository) : IRequestHandler<GetProductByTypeQuery, IReadOnlyList<ProductResponse>>
{
    private readonly IRepositoryManager _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    /// <summary>
    /// Handles a request.
    /// </summary>
    /// <param name="request">Request to get products by type.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the products.
    /// </returns>
    public async Task<IReadOnlyList<ProductResponse>> Handle(GetProductByTypeQuery request, CancellationToken cancellationToken)
    {
        var products = await _repository.Product.GetByTypeAsync(request.Type)
            ?? throw new NotFoundException($"The product with {request.Type} doesn't exist in the database.");
            
        var productResponse = CatalogMapper.GetMapper.Map<IReadOnlyList<ProductResponse>>(products.ToList());

        return productResponse;
    }
}