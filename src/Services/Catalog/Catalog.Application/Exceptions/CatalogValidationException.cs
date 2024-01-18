using System.Collections.Generic;
using FluentValidation.Results;

namespace Catalog.Application.Exceptions;

/// <summary>
/// Represents a validation exception.
/// </summary>
public sealed class CatalogValidationException : ApplicationException
{
    /// <summary>
    /// Gets errors.
    /// </summary>
    public IReadOnlyDictionary<string, string[]> Errors { get; }

    public CatalogValidationException() : base("One or more validation failures have occurred.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public CatalogValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }
}