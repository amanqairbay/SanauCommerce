using Catalog.Core.Entities;

namespace Catalog.Application.Responses;

/// <summary>
/// Represents a file response.
/// </summary>
public class FileResponse
{
    /// <summary>
    /// Gets or sets a buffer.
    /// </summary>
    public byte[] Buffer { get; set; } = default!;

    /// <summary>
    /// Gets or sets a file extension.
    /// </summary>
    public string FileExtension { get; set; } = String.Empty;
}