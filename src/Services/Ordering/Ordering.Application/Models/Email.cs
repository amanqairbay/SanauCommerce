namespace Ordering.Application.Models;

/// <summary>
/// Represents an email.
/// </summary>
public class Email
{
    public string To { get; set; } = String.Empty;
    public string Subject { get; set; } = String.Empty;
    public string Body { get; set; } = String.Empty;
}