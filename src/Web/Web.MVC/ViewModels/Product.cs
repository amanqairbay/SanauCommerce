namespace Web.MVC.ViewModels;

public record Product
{
    public string Id { get; init; } = String.Empty;
    public string Name { get; init; } = String.Empty;
    public string Summary { get; init; } = String.Empty;
    public string Description { get; init; } = String.Empty;
    public string ImageUrl { get; init; } = String.Empty;
    public ProductBrand Brand { get; set; } = default!;
    public ProductType Type { get; set; } = default!;
    public decimal Price { get; init; }
}