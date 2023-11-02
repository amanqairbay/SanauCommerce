namespace Basket.Core.Entities;

/// <summary>
/// Represents a shopping cart.
/// </summary>
public class ShoppingCart
{
    /// <summary>
    /// Gets or sets a username.
    /// </summary>
    public string UserName { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a shopping cart items.
    /// </summary>
    public List<ShoppingCartItem> Items { get; set; } = new();

    // start constructors

    public ShoppingCart() { }
    public ShoppingCart(string userName) => UserName = userName;

    // end constructors
}