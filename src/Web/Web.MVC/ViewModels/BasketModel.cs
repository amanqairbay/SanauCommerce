namespace Web.MVC.ViewModels;

public record BasketModel
{
    public string Username { get; init; } = String.Empty;
    public List<BasketItemModel> Items { get; init; } = new();
    public decimal TotalPrice { get; init; }
}