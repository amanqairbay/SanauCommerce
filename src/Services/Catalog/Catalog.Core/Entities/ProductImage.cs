namespace Catalog.Core.Entities;

/// <summary>
/// Represents a product image.
/// </summary>
public class ProductImage : BaseEntity
{
    /// <summary>
    /// Gets or sets a name.
    /// </summary>
    public string Name { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a main image.
    /// </summary>
    public bool IsMain { get; set; }
}