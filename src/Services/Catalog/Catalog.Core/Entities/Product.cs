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
    /// Gets or sets a brand identifier.
    /// </summary>
    [BsonElement("BrandId")]
    public string BrandId { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a type identifier.
    /// </summary>
    [BsonElement("TypeId")]
    public string TypeId { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets image identifiers.
    /// </summary>
    [BsonElement("ImageIds")]
    public List<string> ImageIds { get; set; } = default!; 

    /// <summary>
    /// Gets or sets a price.
    /// </summary>
    [BsonElement("Price")]
    [BsonRepresentation(BsonType.Decimal128)]
    public decimal Price { get; set; }
}