using Discount.Application.Responses;
using MediatR;

namespace Discount.Application.Queries;

/// <summary>
/// Represents a request for getting a discount.
/// </summary>
public class GetDiscountQuery : IRequest<CouponResponse>
{
    /// <summary>
    /// Gets or sets a product name.
    /// </summary>
    public string ProductName { get; set; }

    public GetDiscountQuery(string productName)
    {
        ProductName = productName;
    }
}