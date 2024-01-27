using Catalog.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Application.Features.ProductImageFeatures.Commands.CreateProductImage;

/// <summary>
/// Represents a command to create product image.
/// </summary>
public class CreateProductImageCommand : IRequest<ProductImageResponse>
{
    /// <summary>
    /// Gets or sets a name.
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a name.
    /// </summary>
    [BsonElement("Name")]
    public string Name { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a product identifier.
    /// </summary>
    [BsonElement("ProductId")]
    public string ProductId { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a main image.
    /// </summary>
    [BsonElement("IsMain")]
    public bool IsMain { get; set; }

    /// <summary>
    /// Gets or sets a file.
    /// </summary>
    public IFormFile FormFile { get; set; } = default!;
}