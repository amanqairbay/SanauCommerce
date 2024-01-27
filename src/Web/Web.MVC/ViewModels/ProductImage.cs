namespace Web.MVC.ViewModels;

public class ProductImage
{
    public string Id { get; set; } = String.Empty;
    public string Name { get; set; } = String.Empty;
    public bool IsMain { get; set; }
    public string ProductId { get; set;} = String.Empty;
}