using Catalog.Core.Entities;
using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Application.Features.Products.Commands.UpdateProduct;

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
    /// Gets or sets a search engine friendly page name.
    /// </summary>
    [BsonElement("SeName")]
    public string SeName { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a product brand.
    /// </summary>
    [BsonElement("Brand")]
    public Brand Brand { get; set; } = default!;

    /// <summary>
    /// Gets or sets a product category.
    /// </summary>
    [BsonElement("Category")]
    public Category Category { get; set; } = default!;

    /// <summary>
    /// Gets or sets photos.
    /// </summary>
    [BsonElement("Photos")]
    public List<Photo> Photos { get; set; } = default!; 

    /// <summary>
    /// Gets or sets a price.
    /// </summary>
    [BsonElement("Price")]
    public decimal Price { get; set; }
}