using MediatR;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder;

/// <summary>
/// Represents the command to update an order.
/// </summary>
public class UpdateOrderCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string UserName { get; set; } = String.Empty;
    public decimal TotalPrice { get; set; }

    // BillingAddress
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string EmailAddress { get; set; } = String.Empty;
    public string AddressLine { get; set; } = String.Empty;
    public string Country { get; set; } = String.Empty;
    public string State { get; set; } = String.Empty;
    public string ZipCode { get; set; } = String.Empty;

    // Payment
    public string CardName { get; set; } = String.Empty;
    public string CardNumber { get; set; } = String.Empty;
    public string Expiration { get; set; } = String.Empty;
    public string CVV { get; set; } = String.Empty;
    public int PaymentMethod { get; set; }
}