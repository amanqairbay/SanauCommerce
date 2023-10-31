namespace Catalog.Core.RequestFeatures;

/// <summary>
/// Represents a product parameters.
/// </summary>
public class ProductParameters : RequestParameters
{
    /// <summary>
    /// Gets or sets a sort.
    /// </summary>
    public string? Sort { get; set; }

    /// <summary>
    /// Gets or sets a search term.
    /// </summary>
    public string? SearchTerm { get; set; }
}