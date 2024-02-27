using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.Brands.Queries.GetBrandList;

/// <summary>
/// Represents a handler to get brands.
/// </summary>
public class GetProductBrandsHandler : IRequestHandler<GetBrandsQuery, IReadOnlyList<BrandResponse>>
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
    /// <param name="request">Request to get brands.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the brands.
    /// </returns>
    public async Task<IReadOnlyList<BrandResponse>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
    {
        var brands = await _repository.Brand.GetAllAsync();
        var brandsResponse = _mapper.Map<IReadOnlyList<BrandResponse>>(brands.ToList());

        return brandsResponse;
    }
}