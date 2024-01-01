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

    /// <summary>
    /// Gets or sets a brand identifier.
    /// </summary>
    public List<string> BrandId { get; set; } = new();

    /// <summary>
    /// Gets or sets a type identifier.
    /// </summary>
    public string? TypeId { get; set; }

    /// <summary>
    /// Gets or sets a product minimum price.
    /// </summary>
    public decimal MinPrice { get; set; } = 0;

    /// <summary>
    /// Gets or sets a product maximum price.
    /// </summary>
    public decimal MaxPrice { get; set; } = 1_000_000_000!;

    /// <summary>
    /// Gets a product valid price range.
    /// </summary>
    public bool ValidPriceRange => ( MaxPrice > MinPrice ) && ( MinPrice >= 0 );
}