using AutoMapper;
using Catalog.Application.Features.ProductTypeFeatures.Querie.GetProductTypeList;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.ProductTypeFeatures.Queries.GetProductTypeList;

/// <summary>
/// Represents a handler to get product types.
/// </summary>
public class GetProductTypesHandler : IRequestHandler<GetProductTypesQuery, IReadOnlyList<ProductTypeResponse>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public GetProductTypesHandler(IMapper mapper, IRepositoryManager repository)
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
    public async Task<IReadOnlyList<ProductTypeResponse>> Handle(GetProductTypesQuery request, CancellationToken cancellationToken)
    {
        var productTypes = await _repository.ProductType.GetAllAsync();
        var productTypesResponse = _mapper.Map<IReadOnlyList<ProductTypeResponse>>(productTypes.ToList());

        return productTypesResponse;
    }
}