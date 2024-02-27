using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.Brands.Queries.GetBrandById;

/// <summary>
/// Represents a handler to get brand by identifier.
/// </summary>
public class GetBrandByIdHandler : IRequestHandler<GetBrandByIdQuery, BrandResponse>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public GetBrandByIdHandler(IMapper mapper, IRepositoryManager repository)
	{
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
	}

    /// <summary>
    /// Handles a request.
    /// </summary>
    /// <param name="request">Request to get brand by identifier.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the brand.
    /// </returns>
    /// <exception cref="NotFoundException">Throw if the brand doesn't exists in database.</exception>
    public async Task<BrandResponse> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
    {
        var brand = await _repository.Brand.GetByIdAsync(request.Id) 
            ?? throw new NotFoundException($"The product brand with id: {request.Id} doesn't exist in the database.");

        var brandResponse = _mapper.Map<BrandResponse>(brand);

        return brandResponse;
    }
}