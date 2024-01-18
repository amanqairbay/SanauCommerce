using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Application.Exceptions;

/// <summary>
/// Represents an application exception.
/// </summary>
public abstract class CatalogApplicationException : Exception
{
    /// <summary>
    /// Gets or sets a title.
    /// </summary>
    public string Title { get; set; }
    
    protected CatalogApplicationException(string title, string message) : base(message)
    {
        Title = title;
    }
}