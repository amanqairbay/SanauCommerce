using Catalog.Application.Responses;
using Catalog.Core.Entities;
using MediatR;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Application.Features.ProductFeatures.Commands.UpdateProduct;

/// <summary>
/// Represents a product create command.
/// </summary>
public class CreateProductCommand : IRequest<ProductResponse>
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
    /// Gets or sets a brand.
    /// </summary>
    [BsonElement("Brand")]
    public ProductBrand Brand { get; set; } = default!;

    /// <summary>
    /// Gets or sets a type.
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
    public decimal Price { get; set; }
}