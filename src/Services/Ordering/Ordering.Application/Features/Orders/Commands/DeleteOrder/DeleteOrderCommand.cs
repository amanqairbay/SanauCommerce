using MediatR;

namespace Ordering.Application.Features.Orders.Commands.DeleteOrder;

/// <summary>
/// Represents the command to delete an order.
/// </summary>
public class DeleteOrderCommand : IRequest<Unit>
{   
    /// <summary>
    /// Gets or sets an identifier.
    /// </summary>
    public int Id { get; set; }
}