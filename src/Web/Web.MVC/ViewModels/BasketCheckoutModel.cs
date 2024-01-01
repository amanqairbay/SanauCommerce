namespace Web.MVC.ViewModels;

public record BasketCheckoutModel
{
    public string Username { get; init; } = String.Empty;
    public decimal TotalPrice { get; init; }

    // BillingAddress
    public string FirstName { get; init; } = String.Empty;
    public string LastName { get; init; } = String.Empty;
    public string EmailAddress { get; init; } = String.Empty;
    public string AddressLine { get; init; } = String.Empty;
    public string Country { get; init; } = String.Empty;
    public string State { get; init; } = String.Empty;
    public string ZipCode { get; init; } = String.Empty;

    // Payment
    public string CardName { get; init; } = String.Empty;
    public string CardNumber { get; init; } = String.Empty;
    public string Expiration { get; init; } = String.Empty;
    public string CVV { get; init; } = String.Empty;
    public int PaymentMethod { get; init; }
}