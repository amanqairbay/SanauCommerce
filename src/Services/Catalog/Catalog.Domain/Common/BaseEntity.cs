using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Domain.Common;

/// <summary>
/// Represents a base entity.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Gets or sets an identifier.
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = String.Empty;
}