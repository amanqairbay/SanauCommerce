using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Features.Photos.Queries.GetPhotoById;

/// <summary>
/// Represents a request to get photo by identifier.
/// </summary>
public class GetPhotoByIdQuery : IRequest<FileResponse>
{
    /// <summary>
    /// Gets or sets a photo identifier.
    /// </summary>
    public string PhotoId { get; set; } = String.Empty;

    public GetPhotoByIdQuery(string photoId)
    {
        PhotoId = photoId;
    }
}