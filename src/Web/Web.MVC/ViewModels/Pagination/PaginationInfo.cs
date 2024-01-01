namespace Web.MVC.ViewModels.Pagination;

public class PaginationInfo
{
    // pageIndex
    public int ActualPage { get; set; } = 1;
    public int TotalPages { get; set; }

    // pageSize
    public int ItemsPerPage { get; set; }

    // count
    public long TotalItems { get; set; }

    public string Previous { get; set; } = String.Empty;
    public string Next { get; set; } = String.Empty;
}