namespace Ordering.Application.Exceptions;

/// <summary>
/// Represents a not found exception.
/// </summary>
public class NotFoundException : ApplicationException
{
    public NotFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) was not found.")
    {
    }
}