namespace Discount.Core.Entities;

/// <summary>
/// Represents a coupon.
/// </summary>
public class Coupon
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
    public decimal Amount {  get; set; }
}