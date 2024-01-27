using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.ProductTypeFeatures.Queries.GetProductTypeById;

/// <summary>
/// Represents a handler to get product type by identifier.
/// </summary>
public class GetProductTypeByIdHandler : IRequestHandler<GetProductTypeByIdQuery, ProductTypeResponse>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public GetProductTypeByIdHandler(IMapper mapper, IRepositoryManager repository)
	{
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
	}

    /// <summary>
    /// Handles a request.
    /// </summary>
    /// <param name="request">Request to get product type by identifier.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product type.
    /// </returns>
    /// <exception cref="NotFoundException">Throw if the product type doesn't exists in database.</exception>
    public async Task<ProductTypeResponse> Handle(GetProductTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var productType = await _repository.ProductType.GetByIdAsync(request.Id) 
            ?? throw new NotFoundException($"The product type with {request.Id} doesn't exist in the database.");

        var productTypeResponse = _mapper.Map<ProductTypeResponse>(productType);

        return productTypeResponse;
    }
}