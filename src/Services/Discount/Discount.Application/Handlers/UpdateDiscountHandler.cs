using Discount.Application.Commands;
using Discount.Application.Mappers;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using MediatR;
using Discount.Application.Responses;

namespace Discount.Application.Handlers;

/// <summary>
/// Represents a handler for updating a discount.
/// </summary>
public class UpdateDiscountHandler : IRequestHandler<UpdateDiscountCommand, CouponResponse>
{
    private readonly IDiscountRepository _discountRepository;

    public UpdateDiscountHandler(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }

    /// <summary>
    /// Handles a request.
    /// </summary>
    /// <param name="command">Command for updating a discount.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    public async Task<CouponResponse> Handle(UpdateDiscountCommand command, CancellationToken cancellationToken)
    {
        var coupon = DiscountMapper.GetMapper.Map<Coupon>(command);

        await _discountRepository.UpdateDiscountAsync(coupon);
        var couponResponse = DiscountMapper.GetMapper.Map<CouponResponse>(coupon);

        return couponResponse;
    }
}