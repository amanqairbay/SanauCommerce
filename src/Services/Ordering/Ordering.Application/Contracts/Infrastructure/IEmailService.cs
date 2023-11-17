using Ordering.Application.Models;

namespace Ordering.Application.Contracts.Infrastructure;

/// <summary>
/// Represents an email service.
/// </summary>
public interface IEmailService
{
    /// <summary>
    /// Sends an email.
    /// </summary>
    /// <param name="email">Email details.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task<bool> SendEmail(Email email);
}