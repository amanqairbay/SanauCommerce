using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.Photos.Queries.GetPhotoByName;

/// <summary>
/// Represents a handler to get photo by name.
/// </summary>
public class GetPhotoByNameQueryHandler : IRequestHandler<GetPhotoByNameQuery, PhotoResponse>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public GetPhotoByNameQueryHandler(IRepositoryManager repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    /// <summary>
    /// Handles a request.
    /// </summary>
    /// <param name="request">Request to get photo by name.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the photo.
    /// </returns>
    public async Task<PhotoResponse> Handle(GetPhotoByNameQuery request, CancellationToken cancellationToken)
    {
        var photoFromDb = await _repository.Photo.GetByNameAsync(request.Name) 
            ?? throw new BadRequestException($"The photo with name: {request.Name} doesn't exists in the database.");

        var photoResponse = _mapper.Map<PhotoResponse>(photoFromDb);

        return photoResponse;
    }
}