using System.Text.Json;

namespace Catalog.Core.Entities.ErrorModel;

/// <summary>
/// Represents an error details.
/// </summary>
public class ErrorDetails
{
    /// <summary>
    /// Gets or sets a status code.
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    /// Gets or sets an error message.
    /// </summary>
    public string Message { get; set; } = String.Empty;
    
    public override string ToString() => JsonSerializer.Serialize(this);
}