using Ordering.Domain.Common;

namespace Ordering.Domain.Entities;

/// <summary>
/// Represents an order.
/// </summary>
public class Order : BaseEntity
{
    /// <summary>
    /// Gets or sets a username.
    /// </summary>
    public string UserName { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a total price.
    /// </summary>
    public decimal TotalPrice { get; set; }


    #region Billing address

    /// <summary>
    /// Gets or sets a first name.
    /// </summary>
    public string FirstName { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a last name
    /// </summary>
    public string LastName { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets an email address.
    /// </summary>
    public string EmailAddress { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets an address line.
    /// </summary>
    public string AddressLine { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a country.
    /// </summary>
    public string Country { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a state.
    /// </summary>
    public string State { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a zipcode.
    /// </summary>
    public string ZipCode { get; set; } = String.Empty;

    #endregion Billing address

    #region Payment

    /// <summary>
    /// Gets or sets a card name.
    /// </summary>
    public string CardName { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a card number.
    /// </summary>
    public string CardNumber { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets an expiration.
    /// </summary>
    public string Expiration { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a CVV.
    /// </summary>
    public string CVV { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a payment method.
    /// </summary>
    public int PaymentMethod { get; set; }

    #endregion Payment
}