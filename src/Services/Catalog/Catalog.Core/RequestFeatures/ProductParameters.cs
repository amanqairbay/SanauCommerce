namespace Catalog.Core.RequestFeatures;

/// <summary>
/// Represents a product parameters.
/// </summary>
public class ProductParameters : RequestParameters
{
    /// <summary>
    /// Gets or sets a brand identifier.
    /// </summary>
    public string? BrandId { get; set; }

    /// <summary>
    /// Gets or sets a type identifier.
    /// </summary>
    public string? TypeId { get; set; }

    /// <summary>
    /// Gets or sets a sort.
    /// </summary>
    public string? Sort { get; set; }

    /// <summary>
    /// Gets or sets a search term.
    /// </summary>
    public string? SearchTerm { get; set; }
}