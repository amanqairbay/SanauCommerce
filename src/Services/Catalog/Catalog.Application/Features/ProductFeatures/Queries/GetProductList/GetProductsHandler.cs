using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.ProductFeatures.Queries.GetProductList;


/// <summary>
/// Represents a handler to get products.
/// </summary>
public class GetProductsHandler : IRequestHandler<GetProductsQuery, IReadOnlyList<ProductResponse>>
{
    private readonly ILogger<GetProductsHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public GetProductsHandler(ILogger<GetProductsHandler> logger, IMapper mapper, IRepositoryManager repository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
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
        var productsResponse = _mapper.Map<IReadOnlyList<ProductResponse>>(products.ToList());
        _logger.LogDebug("Received Product List.Total Count: {productList}", productsResponse.Count);

        return productsResponse;
    }
}