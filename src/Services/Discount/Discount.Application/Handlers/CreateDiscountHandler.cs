using Discount.Application.Commands;
using Discount.Application.Mappers;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using MediatR;
using Discount.Application.Responses;

namespace Discount.Application.Handlers;

/// <summary>
/// Represents a handler for creating a discount.
/// </summary>
public class CreateDiscountHandler : IRequestHandler<CreateDiscountCommand, CouponResponse>
{
    private readonly IDiscountRepository _discountRepository;

    public CreateDiscountHandler(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }

    /// <summary>
    /// Handles a command.
    /// </summary>
    /// <param name="command">Command for creating a discount.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    public async Task<CouponResponse> Handle(CreateDiscountCommand command, CancellationToken cancellationToken)
    {
        var coupon = DiscountMapper.GetMapper.Map<Coupon>(command);

        await _discountRepository.CreateDiscountAsync(coupon);

        var couponResponse = DiscountMapper.GetMapper.Map<CouponResponse>(coupon);

        return couponResponse;
    }
}