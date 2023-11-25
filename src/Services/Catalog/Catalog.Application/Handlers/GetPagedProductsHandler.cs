using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using Catalog.Core.RequestFeatures;
using MediatR;

namespace Catalog.Application.Handlers;

/// <summary>
/// Represents a handler to get all products.
/// </summary>
public class GetPagedProductsHandler : IRequestHandler<GetPagedProductsQuery, Pagination<ProductResponse>>
{
    private readonly IProductRepository _productRepository;

    public GetPagedProductsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    /// <summary>
    /// Handles a request.
    /// </summary>
    /// <param name="request">Request to get products.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the products.
    /// </returns>
    public async Task<Pagination<ProductResponse>> Handle(GetPagedProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetPagedProductsAsync(request.ProductParams);
        var pagedProductResponse = CatalogMapper.GetMapper.Map<Pagination<ProductResponse>>(products);

        return pagedProductResponse;
    }
}