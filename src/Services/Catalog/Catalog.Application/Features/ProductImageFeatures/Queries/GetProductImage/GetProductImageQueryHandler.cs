using Catalog.Application.Exceptions;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Hosting;

namespace Catalog.Application.Features.ProductImageFeatures.Queries.GetProductImage;

/// <summary>
/// Represents a handler to get product image by name.
/// </summary>
public class GetProductImageQueryHandler : IRequestHandler<GetProductImageQuery, PhotoResponse>
{
    private readonly IRepositoryManager _repository;
    private readonly IWebHostEnvironment _environment;

    public GetProductImageQueryHandler(IRepositoryManager repository, IWebHostEnvironment environment)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _environment = environment ?? throw new ArgumentNullException(nameof(repository));
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
    public async Task<PhotoResponse> Handle(GetProductImageQuery request, CancellationToken cancellationToken)
    {
        var productImage = await _repository.ProductImage.GetByNameAsync(request.ProductImageId)
            ?? throw new NotFoundException($"The product image with {request.ProductImageId} doesn't exist in the database.");

        var webRoot = _environment.WebRootPath;
        var path = Path.Combine(webRoot, $"img{Path.DirectorySeparatorChar}products/" + productImage.Name);

        string imageFileExtension = Path.GetExtension(productImage.Name);
        string mimetype = GetImageMimeTypeFromImageFileExtension(imageFileExtension);

        var buffer = await System.IO.File.ReadAllBytesAsync(path);

        return new PhotoResponse { Buffer = buffer, FileExtension = mimetype };
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