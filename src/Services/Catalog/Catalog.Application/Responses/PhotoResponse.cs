using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Application.Responses;

/// <summary>
/// Represents a photo response.
/// </summary>
public class PhotoResponse
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
    /// Gets or sets a product identifier.
    /// </summary>
    [BsonElement("ProductId")]
    public string ProductId { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a main image.
    /// </summary>
    [BsonElement("IsMain")]
    public bool IsMain { get; set; }        
}