namespace Ordering.Domain.Common;

/// <summary>
/// Represents a base entity
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Gets or sets an identifier.
    /// </summary>
    public int Id { get; protected set; }

    /// <summary>
    /// Gets or sets an order creator.
    /// </summary>
    public string CreatedBy { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a created date.
    /// </summary>
    public DateTime CreatedDate { get; set; }

    /// <summary>
    /// Gets or sets the last modifier.
    /// </summary>
    public string LastModifiedBy { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets the last modified date.
    /// </summary>
    public DateTime LastModifiedDate { get; set; }
}