using MediatR;

namespace Discount.Application.Commands;

/// <summary>
/// Represents a command for deleting a discount.
/// </summary>
public class DeleteDiscountCommand : IRequest<bool>
{
    /// <summary>
    /// Gets or sets a product name.
    /// </summary>
    public string ProductName { get; set; }

    public DeleteDiscountCommand(string productName)
    {
        ProductName = productName;
    }
}