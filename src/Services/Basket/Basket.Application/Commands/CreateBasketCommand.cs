using Basket.Application.Responses;
using Basket.Core.Entities;
using MediatR;

namespace Basket.Application.Commands;

/// <summary>
/// Represents a create basket command.
/// </summary>
public class CreateBasketCommand : IRequest<ShoppingCartResponse>
{
	/// <summary>
	/// Gets or sets the customer's username.
	/// </summary>
	public string UserName { get; set; } = String.Empty;

	/// <summary>
	/// Gets or sets the shopping cart's items.
	/// </summary>
	public List<ShoppingCartItem> Items { get; set; } = default!;

    public CreateBasketCommand(string userName , List<ShoppingCartItem> items)
    {
        UserName = userName;
        Items = items;
    }
}