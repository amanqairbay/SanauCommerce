using Catalog.Domain.Common;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Domain.Entities;

/// <summary>
/// Represents a category.
/// </summary>
public class Category : BaseEntity
{
    /// <summary>
    /// Gets or sets a name.
    /// </summary>
    [BsonElement("Name")]
    public string Name { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets product types identifiers.
    /// </summary>
    [BsonElement("ProductTypeIds")]
    public List<string> ProductTypeIds { get; set; } = default!;
}