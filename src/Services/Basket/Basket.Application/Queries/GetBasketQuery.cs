using Basket.Application.Responses;
using MediatR;

namespace Basket.Application.Queries;

/// <summary>
/// Represents a get basket query.
/// </summary>
public class GetBasketQuery : IRequest<ShoppingCartResponse>
{
	/// <summary>
	/// Gets or sets a username.
	/// </summary>
	public string UserName { get; set; } = String.Empty;

    public GetBasketQuery(string userName)
    {
        UserName = userName;
    }
}