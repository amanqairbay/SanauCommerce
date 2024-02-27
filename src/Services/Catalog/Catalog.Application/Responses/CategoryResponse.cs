using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Application.Responses;

/// <summary>
/// Represents a category response.
/// </summary>
public class CategoryResponse
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
}