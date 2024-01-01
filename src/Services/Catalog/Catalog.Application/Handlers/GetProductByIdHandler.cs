using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Entities.Exceptions;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

/// <summary>
/// Represents a handler to get product by identifier.
/// </summary>
public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
{
    private readonly IRepositoryManager _repository;

    public GetProductByIdHandler(IRepositoryManager repository)
	{
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
	}

    /// <summary>
    /// Handles a request.
    /// </summary>
    /// <param name="request">Request to get products by identifier.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the products.
    /// </returns>
    /// <exception cref="NotFoundException">Throw if the product doesn't exists in database.</exception>
    public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _repository.Product.GetByIdAsync(request.Id)
            ?? throw new NotFoundException($"The product with {request.Id} doesn't exist in the database.");

        var productResponse = CatalogMapper.GetMapper.Map<ProductResponse>(product);

        return productResponse;
    }
}