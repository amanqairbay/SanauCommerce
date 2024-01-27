using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.ProductBrandFeatures.Queries.GetProductBrandById;

/// <summary>
/// Represents a handler to get product brand by identifier.
/// </summary>
public class GetProductBrandByIdHandler : IRequestHandler<GetProductBrandByIdQuery, ProductBrandResponse>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public GetProductBrandByIdHandler(IMapper mapper, IRepositoryManager repository)
	{
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
	}

    /// <summary>
    /// Handles a request.
    /// </summary>
    /// <param name="request">Request to get product brand by identifier.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product brand.
    /// </returns>
    /// <exception cref="NotFoundException">Throw if the product brand doesn't exists in database.</exception>
    public async Task<ProductBrandResponse> Handle(GetProductBrandByIdQuery request, CancellationToken cancellationToken)
    {
        var productBrand = await _repository.ProductBrand.GetByIdAsync(request.Id) 
            ?? throw new NotFoundException($"The product brand with id: {request.Id} doesn't exist in the database.");

        var productBrandResponse = _mapper.Map<ProductBrandResponse>(productBrand);

        return productBrandResponse;
    }
}