using Discount.Application.Responses;
using MediatR;

namespace Discount.Application.Commands;

/// <summary>
/// Represents a command for creating a discount.
/// </summary>
public class CreateDiscountCommand : IRequest<CouponResponse>
{
    /// <summary>
    /// Gets or sets a product name.
    /// </summary>
    public string ProductName { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a description.
    /// </summary>
    public string Description { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets an amount.
    /// </summary>
    public int Amount { get; set; }
}