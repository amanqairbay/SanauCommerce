namespace Web.MVC.ViewModels;

public record Product
{
    public string Id { get; init; } = String.Empty;
    public string Name { get; init; } = String.Empty;
    public string Category { get; init; } = String.Empty;
    public string Summary { get; init; } = String.Empty;
    public string Description { get; init; } = String.Empty;
    public string ImageFile { get; init; } = String.Empty;
    public decimal Price { get; init; }
}