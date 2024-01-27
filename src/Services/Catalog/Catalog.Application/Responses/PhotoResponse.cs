using Catalog.Core.Entities;

namespace Catalog.Application.Responses;

/// <summary>
/// Represents a photo response.
/// </summary>
public class PhotoResponse
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