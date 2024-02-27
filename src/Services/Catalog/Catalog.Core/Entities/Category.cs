using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Core.Entities;

/// <summary>
/// Represents a product category.
/// </summary>
public class Category : BaseEntity
{
    /// <summary>
    /// Gets or sets a name.
    /// </summary>
    [BsonElement("Name")]
    public string Name { get; set; } = String.Empty;
}