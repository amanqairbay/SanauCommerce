using Basket.Application.Commands;
using Basket.Application.Mappers;
using Basket.Application.Responses;
using Basket.Core.Entities;
using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Handlers;

public class CreateBasketHandler : IRequestHandler<CreateBasketCommand, ShoppingCartResponse>
{
    private readonly IBasketRepository _basketRepository;

    public CreateBasketHandler(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }

    /// <summary>
    /// Handles a command.
    /// </summary>
    /// <param name="command">Command for creating a basket.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    public async Task<ShoppingCartResponse> Handle(CreateBasketCommand command, CancellationToken cancellationToken)
    {
        var shoppingCart = await _basketRepository.UpdateBasketAsync(new ShoppingCart
        {
            UserName = command.UserName,
            Items = command.Items
        });

        var shoppingCartResponse = BasketMapper.GetMapper.Map<ShoppingCartResponse>(shoppingCart);

        return shoppingCartResponse;
    }
}