using Catalog.Application.Responses;
using Catalog.Core.Entities;
using MediatR;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Application.Features.Products.Commands.CreateProduct;

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
    /// Gets or sets photos.
    /// </summary>
    [BsonElement("Photo")]
    public List<Photo> Photos { get; set; } = default!; 

    /// <summary>
    /// Gets or sets a price.
    /// </summary>
    [BsonElement("Price")]
    public decimal Price { get; set; }
}