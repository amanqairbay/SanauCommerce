using Discount.Application.Mappers;
using Discount.Application.Queries;
using Discount.Core.Repositories;
using MediatR;
using Discount.Application.Responses;

namespace Discount.Application.Handlers;

/// <summary>
/// Represents a handler for getting a discount.
/// </summary>
public class GetDiscountHandler : IRequestHandler<GetDiscountQuery, CouponResponse>
{
    private readonly IDiscountRepository _discountRepository;

    public GetDiscountHandler(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }

    /// <summary>
    /// Handles a request.
    /// </summary>
    /// <param name="request">Request for getting a discount.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    public async Task<CouponResponse> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
    {
        var coupon = await _discountRepository.GetDiscountAsync(request.ProductName);

        var couponResponse = DiscountMapper.GetMapper.Map<CouponResponse>(coupon);

        return couponResponse;
    }
}