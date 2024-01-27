using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.ProductImageFeatures.Queries.GetProductImageByName;

/// <summary>
/// Represents a handler to get product image by name.
/// </summary>
public class GetProductImageByNameQueryHandler : IRequestHandler<GetProductImageByNameQuery, ProductImageResponse>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public GetProductImageByNameQueryHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<ProductImageResponse> Handle(GetProductImageByNameQuery request, CancellationToken cancellationToken)
    {
        var productImageFromDb = await _repository.ProductImage.GetByNameAsync(request.Name) 
            ?? throw new BadRequestException($"The product with name: {request.Name} doesn't exists in the database.");

        var productImage = _mapper.Map<ProductImageResponse>(productImageFromDb);

        return productImage;
    }
}