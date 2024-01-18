namespace Catalog.Application.Exceptions;

/// <summary>
/// Represents a bad request exception.
/// </summary>
/// <param name="message">An error message.</param>
public sealed class BadRequestException : CatalogApplicationException
{
    public BadRequestException(string message) : base("Bad Request", message)
    {
        
    }
}