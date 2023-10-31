using MediatR;

namespace Catalog.Application.Commands;

/// <summary>
/// Represents a product delete comand.
/// </summary>
public class DeleteProductCommand : IRequest<bool>
{
    /// <summary>
    /// Gets or sets a product identifier.
    /// </summary>
    public string Id { get; set; }

    public DeleteProductCommand(string id)
    {
        Id = id;
    }
}