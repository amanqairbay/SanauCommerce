using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

/// <summary>
/// Represents a handler to get products name.
/// </summary>
public class GetProductsByNameHandler : IRequestHandler<GetProductByNameQuery, IReadOnlyList<ProductResponse>>
{
    private readonly IProductRepository _productRepository;

    public GetProductsByNameHandler(IProductRepository productRepository)
	{
        _productRepository = productRepository;
	}

    /// <summary>
    /// Handles a request.
    /// </summary>
    /// <param name="request">Request to get products by name.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the products.
    /// </returns>
    public async Task<IReadOnlyList<ProductResponse>> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetProductByNameAsync(request.Name);
        var productResponse = CatalogMapper.GetMapper.Map<IReadOnlyList<ProductResponse>>(products.ToList());

        return productResponse;
    }
}