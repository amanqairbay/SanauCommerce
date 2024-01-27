using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.ProductBrandFeatures.Queries.GetProductBrandList;

/// <summary>
/// Represents a handler to get product brands.
/// </summary>
public class GetProductBrandsHandler : IRequestHandler<GetProductBrandsQuery, IReadOnlyList<ProductBrandResponse>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public GetProductBrandsHandler(IMapper mapper, IRepositoryManager repository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    /// <summary>
    /// Handles a request.
    /// </summary>
    /// <param name="request">Request to get product types.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product types.
    /// </returns>
    public async Task<IReadOnlyList<ProductBrandResponse>> Handle(GetProductBrandsQuery request, CancellationToken cancellationToken)
    {
        var productBrands = await _repository.ProductBrand.GetAllAsync();
        var productBrandsResponse = _mapper.Map<IReadOnlyList<ProductBrandResponse>>(productBrands.ToList());

        return productBrandsResponse;
    }
}