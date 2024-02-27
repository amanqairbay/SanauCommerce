using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Core.Services;
using MediatR;

namespace Catalog.Application.Features.Photos.Commands.CreatePhoto;

/// <summary>
/// Represents a create photo handler.
/// </summary>
public class CreatePhotoCommandHandler : IRequestHandler<CreatePhotoCommand, PhotoResponse>
{
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public CreatePhotoCommandHandler(IFileService fileService, IMapper mapper, IRepositoryManager repository)
    {
        _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

     /// <summary>
    /// Handles a command.
    /// </summary>
    /// <param name="command">Command for photo create.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the photo.
    /// </returns>
    /// /// <exception cref="BadRequestException">Thrown when a photo cannot be created.</exception>
    public async Task<PhotoResponse> Handle(CreatePhotoCommand command, CancellationToken cancellationToken)
    {
        if (command.FormFile is null)
        {
            throw new BadRequestException("Upload Failure. No files to upload.");
        }

        var fileSaveResult = _fileService.SaveImage(command.FormFile, command.Name);

        if (fileSaveResult.Item1 is not true)
        {
            throw new BadRequestException(message: fileSaveResult.Item2);
        }

        var productFromDb = await _repository.Product.GetByIdAsync(command.ProductId) 
            ?? throw new BadRequestException($"The product with {command.Id} doesn't exists in the database."); 

        var newPhoto = new Photo
        {
            Name = fileSaveResult.Item2,
            IsMain = command.IsMain,
            ProductId = command.ProductId
        };

        var createdPhoto = await _repository.Photo.CreateAsync(newPhoto);
        var photoResponse = _mapper.Map<PhotoResponse>(createdPhoto);

        return photoResponse;
    }
}