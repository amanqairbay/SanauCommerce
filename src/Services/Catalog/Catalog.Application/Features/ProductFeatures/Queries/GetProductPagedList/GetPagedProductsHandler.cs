using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using Catalog.Core.RequestFeatures;
using MediatR;

namespace Catalog.Application.Features.ProductFeatures.Queries.GetProductPagedList;

/// <summary>
/// Represents a handler to get all products.
/// </summary>
public class GetPagedProductsHandler(IRepositoryManager repository, IMapper mapper) : IRequestHandler<GetPagedProductsQuery, Pagination<ProductResponse>>
{
    private readonly IRepositoryManager _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

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
        if (!request.ProductParams.ValidPriceRange)
            throw new BadRequestException("Maximum price can't be less than minimum price. And minimum price can't be less than 0.");
            
        var pagedProducts = await _repository.Product.GetAllPagedAsync(request.ProductParams);
        var pagedProductResponse = _mapper.Map<Pagination<ProductResponse>>(pagedProducts);
        return pagedProductResponse; 
    }
}