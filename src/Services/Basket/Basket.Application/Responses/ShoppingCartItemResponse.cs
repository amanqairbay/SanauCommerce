namespace Basket.Application.Responses;

/// <summary>
/// Represents a shopping cart item response.
/// </summary>
public class ShoppingCartItemResponse
{
    /// <summary>
    /// Gets or sets a quantity.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets a color.
    /// </summary>
    public string Color { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a price.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets a product identifier.
    /// </summary>
    public string ProductId { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a product name.
    /// </summary>
    public string ProductName { get; set; } = String.Empty;
}