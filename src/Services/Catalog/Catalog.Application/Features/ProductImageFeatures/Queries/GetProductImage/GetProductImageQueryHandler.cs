using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.ProductImageFeatures.Queries.GetProductImage;

/// <summary>
/// Represents a handler to get product image by name.
/// </summary>
public class GetProductImageQueryHandler : IRequestHandler<GetProductImageQuery, ProductImageResponse>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public GetProductImageQueryHandler(IMapper mapper, IRepositoryManager repository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    /// <summary>
    /// Handles a request.
    /// </summary>
    /// <param name="request">Request to get product image by name.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product image.
    /// </returns>
    public async Task<ProductImageResponse> Handle(GetProductImageQuery request, CancellationToken cancellationToken)
    {
        var productImage = await _repository.ProductImage.GetByNameAsync(request.Name)
            ?? throw new NotFoundException($"The product image with {request.Name} doesn't exist in the database.");
            
        var productImageResponse = _mapper.Map<ProductImageResponse>(productImage);

        return productImageResponse;
    }
}