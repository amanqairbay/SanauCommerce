namespace Catalog.Core.RequestFeatures;

/// <summary>
/// Represents a request parameters.
/// </summary>
public abstract class RequestParameters
{
    /// <summary>
    /// Maximum of 70 rows per page.
    /// </summary>
    const int maxPageSize = 70;

    /// <summary>
    /// Gets or sets page number.
    /// </summary>
    public int PageIndex { get; set; } = 1;

    /// <summary>
    /// Page size.
    /// </summary>
    private int _pageSize = 10;

    /// <summary>
    /// Gets or sets a page size.
    /// </summary>
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        
    }
}