using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Core.Entities;

/// <summary>
/// Represents a product.
/// </summary>
public class Product : BaseEntity
{
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
    /// Gets or sets images.
    /// </summary>
    [BsonElement("Photos")]
    public List<Photo> Photos { get; set; } = default!;

    /// <summary>
    /// Gets or sets a price.
    /// </summary>
    [BsonElement("Price")]
    [BsonRepresentation(BsonType.Decimal128)]
    public decimal Price { get; set; } 
}