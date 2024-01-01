namespace Catalog.Core.Entities.Exceptions;

/// <summary>
/// Represents a bad request exception.
/// </summary>
/// <param name="message">An error message.</param>
public sealed class BadRequestException(string message) : Exception(message)
{

}