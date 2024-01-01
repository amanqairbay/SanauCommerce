namespace Web.MVC.ViewModels;

public record BasketItemModel 
{
    public int Quantity { get; init; }
    public string Color { get; init; } = String.Empty;
    public decimal Price { get; init; }
    public string ProductId { get; init; } = String.Empty;
    public string ProductName { get; init; } = String.Empty;
}