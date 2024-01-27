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
    public ProductBrand Brand { get; set; } = default!;

    /// <summary>
    /// Gets or sets a product type.
    /// </summary>
    [BsonElement("Type")]
    public ProductType Type { get; set; } = default!;

    /// <summary>
    /// Gets or sets images.
    /// </summary>
    [BsonElement("Images")]
    public List<ProductImage> Images { get; set; } = default!;

    /// <summary>
    /// Gets or sets a price.
    /// </summary>
    [BsonElement("Price")]
    [BsonRepresentation(BsonType.Decimal128)]
    public decimal Price { get; set; } 
}