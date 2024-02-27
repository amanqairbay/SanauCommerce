using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.Products.Queries.GetProductByName;

/// <summary>
/// Represents a handler to get product by name.
/// </summary>
public class GetProductsByNameHandler : IRequestHandler<GetProductByNameQuery, ProductResponse>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public GetProductsByNameHandler(IMapper mapper, IRepositoryManager repository)
	{
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
            
        var productResponse = _mapper.Map<ProductResponse>(product);

        return productResponse;
    }
}