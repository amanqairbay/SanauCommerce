using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.ProductFeatures.Queries.GetProductByType;

/// <summary>
/// Represents a handler to get products category.
/// </summary>
public class GetProductsByTypeHandler : IRequestHandler<GetProductByTypeQuery, IReadOnlyList<ProductResponse>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public GetProductsByTypeHandler(IMapper mapper, IRepositoryManager repository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

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
            
        var productResponse = _mapper.Map<IReadOnlyList<ProductResponse>>(products.ToList());

        return productResponse;
    }
}