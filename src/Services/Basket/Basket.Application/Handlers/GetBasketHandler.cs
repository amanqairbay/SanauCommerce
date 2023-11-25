using Basket.Application.Mappers;
using Basket.Application.Queries;
using Basket.Application.Responses;
using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Handlers;

/// <summary>
/// Represents a get basket handler.
/// </summary>
public class GetBasketHandler : IRequestHandler<GetBasketQuery, ShoppingCartResponse>
{
    private readonly IBasketRepository _basketRepository;

	public GetBasketHandler(IBasketRepository basketRepository)
	{
        _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
	}

    /// <summary>
    /// Handles a request.
    /// </summary>
    /// <param name="request">Request to get basket by name.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    public async Task<ShoppingCartResponse> Handle(GetBasketQuery request, CancellationToken cancellationToken)
    {
        var shoppingCart = await _basketRepository.GetBasketAsync(request.UserName);

        var shoppingCartResponse = BasketMapper.GetMapper.Map<ShoppingCartResponse>(shoppingCart);

        return shoppingCartResponse;
    }
}