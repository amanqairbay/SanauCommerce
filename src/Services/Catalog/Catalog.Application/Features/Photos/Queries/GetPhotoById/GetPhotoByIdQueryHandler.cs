using Catalog.Application.Exceptions;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Hosting;

namespace Catalog.Application.Features.Photos.Queries.GetPhotoById;

/// <summary>
/// Represents a handler to get photo by identifier.
/// </summary>
public class GetPhotoByIdQueryHandler : IRequestHandler<GetPhotoByIdQuery, FileResponse>
{
    private readonly IRepositoryManager _repository;
    private readonly IWebHostEnvironment _environment;

    public GetPhotoByIdQueryHandler(IRepositoryManager repository, IWebHostEnvironment environment)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _environment = environment ?? throw new ArgumentNullException(nameof(repository));
    }

    /// <summary>
    /// Handles a request.
    /// </summary>
    /// <param name="request">Request to get photo by identifier.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the photo.
    /// </returns>
    public async Task<FileResponse> Handle(GetPhotoByIdQuery request, CancellationToken cancellationToken)
    {
        var photo = await _repository.Photo.GetByIdAsync(request.PhotoId)
            ?? throw new NotFoundException($"The photo with id: {request.PhotoId} doesn't exist in the database.");

        var webRoot = _environment.WebRootPath;
        var path = Path.Combine(webRoot, $"img{Path.DirectorySeparatorChar}products/" + photo.Name);

        string imageFileExtension = Path.GetExtension(photo.Name);
        string mimetype = GetImageMimeTypeFromImageFileExtension(imageFileExtension);

        var buffer = await System.IO.File.ReadAllBytesAsync(path);

        return new FileResponse { Buffer = buffer, FileExtension = mimetype };
    }

    private static string GetImageMimeTypeFromImageFileExtension(string extension)
    {
        string mimetype = extension switch
        {
            ".png" => "image/png",
            ".gif" => "image/gif",
            ".jpg" or ".jpeg" => "image/jpeg",
            ".bmp" => "image/bmp",
            ".tiff" => "image/tiff",
            ".wmf" => "image/wmf",
            ".jp2" => "image/jp2",
            ".svg" => "image/svg+xml",
            _ => "application/octet-stream",
        };
        return mimetype;
    }
}