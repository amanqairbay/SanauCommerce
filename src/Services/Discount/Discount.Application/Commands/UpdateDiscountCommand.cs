using Discount.Application.Responses;
using MediatR;

namespace Discount.Application.Commands;

/// <summary>
/// Represents a command for updating a discount.
/// </summary>
public class UpdateDiscountCommand : IRequest<CouponResponse>
{
    /// <summary>
    /// Gets or sets an identifier.
    /// </summary>
    public int Id { get; set; }

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