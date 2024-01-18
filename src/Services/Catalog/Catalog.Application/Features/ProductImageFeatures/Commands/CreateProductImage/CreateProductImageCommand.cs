using Catalog.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Catalog.Application.Features.ProductImageFeatures.Commands.CreateProductImage;

/// <summary>
/// Represents a command to create product image.
/// </summary>
public class CreateProductImageCommand : IRequest<ProductImageResponse>
{
    /// <summary>
    /// Gets or sets a name.
    /// </summary>
    public string Name { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a main image.
    /// </summary>
    public bool IsMain { get; set; }

    /// <summary>
    /// Gets or sets a file.
    /// </summary>
    public IFormFile FormFile { get; set; } = default!;
}