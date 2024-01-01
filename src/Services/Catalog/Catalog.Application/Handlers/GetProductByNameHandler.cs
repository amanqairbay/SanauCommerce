using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Entities.Exceptions;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

/// <summary>
/// Represents a handler to get products name.
/// </summary>
public class GetProductsByNameHandler : IRequestHandler<GetProductByNameQuery, ProductResponse>
{
    private readonly IRepositoryManager _repository;

    public GetProductsByNameHandler(IRepositoryManager repository)
	{
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
	}

    /// <summary>
    /// Handles a request.
    /// </summary>
    /// <param name="request">Request to get product by name.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product.
    /// </returns>
    public async Task<ProductResponse> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
    {
        var product = await _repository.Product.GetByNameAsync(request.Name)
            ?? throw new NotFoundException($"The product with {request.Name} doesn't exist in the database.");
            
        var productResponse = CatalogMapper.GetMapper.Map<ProductResponse>(product);

        return productResponse;
    }
}