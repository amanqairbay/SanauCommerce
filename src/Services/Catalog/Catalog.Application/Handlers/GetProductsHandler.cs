using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Handlers;


/// <summary>
/// Represents a handler to get products.
/// </summary>
public class GetProductsHandler : IRequestHandler<GetProductsQuery, IReadOnlyList<ProductResponse>>
{
    private readonly IRepositoryManager _repository;
    private readonly ILogger<GetProductsHandler> _logger;

    public GetProductsHandler(IRepositoryManager repository, ILogger<GetProductsHandler> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
    public async Task<IReadOnlyList<ProductResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _repository.Product.GetAllAsync();
        var productsResponse = CatalogMapper.GetMapper.Map<IReadOnlyList<ProductResponse>>(products.ToList());
        _logger.LogDebug("Received Product List.Total Count: {productList}", productsResponse.Count);

        return productsResponse;
    }
}