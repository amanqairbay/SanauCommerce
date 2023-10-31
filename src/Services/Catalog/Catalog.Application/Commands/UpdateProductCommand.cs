using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Application.Commands;

/// <summary>
/// Represents a product update command.
/// </summary>
public class UpdateProductCommand : IRequest<bool>
{
    /// <summary>
    /// Gets or sets an identifier.
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