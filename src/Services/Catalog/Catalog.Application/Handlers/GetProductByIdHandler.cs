using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

/// <summary>
/// Represents a handler to get product by identifier.
/// </summary>
public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdHandler(IProductRepository productRepository)
	{
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
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
    /// <exception cref="ApplicationException">Throw if the product doesn't exists in database.</exception>
    public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductByIdAsync(request.Id)
            ?? throw new ApplicationException($"The product with {request.Id} doesn't exists in database.");

        var productResponse = CatalogMapper.GetMapper.Map<ProductResponse>(product);

        return productResponse;
    }
}