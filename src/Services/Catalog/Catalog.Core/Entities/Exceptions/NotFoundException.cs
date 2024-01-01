namespace Catalog.Core.Entities.Exceptions;

/// <summary>
/// Represents a not foun exception.
/// </summary>
/// <param name="message">An error message.</param>
public sealed class NotFoundException(string message) : Exception(message) 
{
}