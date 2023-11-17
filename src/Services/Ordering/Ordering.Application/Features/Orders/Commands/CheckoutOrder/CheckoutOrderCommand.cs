using MediatR;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrder;

/// <summary>
/// Represents a checkout order command.
/// </summary>
public class CheckoutOrderCommand : IRequest<int>
{
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