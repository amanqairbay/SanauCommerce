using Catalog.Domain.Common;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Domain.Entities;

/// <summary>
/// Represents a product type.
/// </summary>/
public class ProductType : BaseEntity 
{
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
    /// Gets or sets a category identifier.
    /// </summary>
    [BsonElement("CategoryId")]
    public string CategoryId { get; set; } = String.Empty;
}