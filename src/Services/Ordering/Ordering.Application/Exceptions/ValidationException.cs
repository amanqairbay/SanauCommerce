using FluentValidation.Results;

namespace Ordering.Application.Exceptions;

/// <summary>
/// Represents a validation exception.
/// </summary>
public class ValidationException : ApplicationException
{
    /// <summary>
    /// Gets errors.
    /// </summary>
    public IDictionary<string, string[]> Errors { get; }

    public ValidationException() : base("One or more validation failures have occurred.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }
}