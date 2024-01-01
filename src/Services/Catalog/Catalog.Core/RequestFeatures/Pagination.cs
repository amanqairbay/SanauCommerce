namespace Catalog.Core.RequestFeatures;

/// <summary>
/// Represents a pagination.
/// </summary>
/// <typeparam name="T">Entity type.</typeparam>
public class Pagination<T> where T : class
{
    /// <summary>
	/// Gets or sets a page index.
	/// </summary>
	public int PageIndex { get; set; }

    /// <summary>
    /// Gets or sets a page size.
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Gets or sets a count.
    /// </summary>
    public long Count { get; set; }

    /// <summary>
    /// Gets or sets a data list.
    /// </summary>
    public IReadOnlyList<T> Data { get; set; } = default!;

    public Pagination()
	{
	}

    public Pagination(int pageIndex, int pageSize, long count, IReadOnlyList<T> data)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        Count = count;
        Data = data;
    }
}