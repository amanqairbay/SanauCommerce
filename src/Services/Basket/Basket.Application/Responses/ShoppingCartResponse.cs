namespace Basket.Application.Responses;

/// <summary>
/// Represents a shopping cart response.
/// </summary>
public class ShoppingCartResponse
{
    /// <summary>
    /// Gets or sets a username.
    /// </summary>
    public string UserName { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a shopping cart items.
    /// </summary>
    public List<ShoppingCartItemResponse> Items { get; set; } = new List<ShoppingCartItemResponse>();

    /// <summary>
    /// Gets a total price.
    /// </summary>
    public decimal TotalPrice
    {
        get 
        {
            decimal totalPrice = 0;

            foreach (var item in Items)
            {
                totalPrice += item.Price * item.Quantity;
            }

            return totalPrice;
        }
    }

    // start constructors

    public ShoppingCartResponse() { }
    public ShoppingCartResponse(string userName) => UserName = userName;

    // end constructors
}