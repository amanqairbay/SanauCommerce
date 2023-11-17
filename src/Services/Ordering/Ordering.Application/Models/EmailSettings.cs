namespace Ordering.Application.Models;

/// <summary>
/// Represents an email settings.
/// </summary>
public class EmailSettings
{
    public string ApiKey { get; set; } = String.Empty;
    public string FromAddress { get; set; } = String.Empty;
    public string FromName { get; set; } = String.Empty;
}