using Catalog.Application.Responses;
using MediatR;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Application.Commands;

/// <summary>
/// Represents a product create command.
/// </summary>
public class CreateProductCommand : IRequest<ProductResponse>
{
    /// <summary>
    /// Gets or sets a name.
    /// </summary>
    [BsonElement("Name")]
    public string Name { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a category.
    /// </summary>
    [BsonElement("Category")]
    public string Category { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a summary.
    /// </summary>
    [BsonElement("Summary")]
    public string Summary { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a description.
    /// </summary>
    [BsonElement("Description")]
    public string Description { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets an image file.
    /// </summary>
    [BsonElement("ImageFile")]
    public string ImageFile { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a price.
    /// </summary>
    [BsonElement("Price")]
    public decimal Price { get; set; }
}