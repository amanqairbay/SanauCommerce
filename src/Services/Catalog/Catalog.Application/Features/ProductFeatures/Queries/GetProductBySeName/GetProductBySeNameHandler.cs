using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.ProductFeatures.Queries.GetProductBySeName;

/// <summary>
/// Represents a handler to get product by search engine friendly page name..
/// </summary>
public class GetProductsBySeNameHandler : IRequestHandler<GetProductBySeNameQuery, ProductResponse>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public GetProductsBySeNameHandler(IMapper mapper, IRepositoryManager repository)
	{
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
	}

    /// <summary>
    /// Handles a request.
    /// </summary>
    /// <param name="request">Request to get product by search engine friendly page name..</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product.
    /// </returns>
    public async Task<ProductResponse> Handle(GetProductBySeNameQuery request, CancellationToken cancellationToken)
    {
        var product = await _repository.Product.GetBySeNameAsync(request.SeName)
            ?? throw new NotFoundException($"The product with seName: {request.SeName} doesn't exist in the database.");
            
        var productResponse = _mapper.Map<ProductResponse>(product);

        return productResponse;
    }
}