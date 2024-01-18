namespace Catalog.Application.Exceptions;

/// <summary>
/// Represents a not foun exception.
/// </summary>
/// <param name="message">An error message.</param>
public sealed class NotFoundException : CatalogApplicationException
{
    public NotFoundException(string message) : base("Not Found", message) 
    {
        
    }
}