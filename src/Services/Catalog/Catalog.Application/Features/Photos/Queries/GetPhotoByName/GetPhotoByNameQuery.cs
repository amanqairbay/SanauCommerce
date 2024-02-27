using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Features.Photos.Queries.GetPhotoByName;

/// <summary>
/// Represents a request to get photo by name.
/// </summary>
public class GetPhotoByNameQuery : IRequest<PhotoResponse>
{
    /// <summary>
    /// Gets or sets a photo name.
    /// </summary>
    public string Name { get; set; } = String.Empty;

    public GetPhotoByNameQuery(string name)
    {
        Name = name;
    }
}