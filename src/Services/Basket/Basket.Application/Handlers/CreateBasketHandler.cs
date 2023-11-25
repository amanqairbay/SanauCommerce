using Basket.Application.Commands;
using Basket.Application.GrpcServices;
using Basket.Application.Mappers;
using Basket.Application.Responses;
using Basket.Core.Entities;
using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Handlers;

public class CreateBasketHandler : IRequestHandler<CreateBasketCommand, ShoppingCartResponse>
{
    private readonly DiscountGrpcService _discountGrpcService;
    private readonly IBasketRepository _basketRepository;

    public CreateBasketHandler(DiscountGrpcService discountGrpcService, IBasketRepository basketRepository)
    {
        _discountGrpcService = discountGrpcService ?? throw new ArgumentNullException(nameof(discountGrpcService));
        _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
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
        // communicate with Discount.Grpc
        foreach (var item in command.Items)
        {
            var coupon = await _discountGrpcService.GetDiscountAsync(item.ProductName);
            item.Price -= coupon.Amount;
        }

        var shoppingCart = await _basketRepository.UpdateBasketAsync(new ShoppingCart
        {
            UserName = command.UserName,
            Items = command.Items
        });

        var shoppingCartResponse = BasketMapper.GetMapper.Map<ShoppingCartResponse>(shoppingCart);

        return shoppingCartResponse;
    }
}