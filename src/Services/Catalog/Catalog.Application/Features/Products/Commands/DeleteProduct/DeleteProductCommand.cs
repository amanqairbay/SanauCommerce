using MediatR;

namespace Catalog.Application.Features.Products.Commands.DeleteProduct;

/// <summary>
/// Represents a product delete comand.
/// </summary>
public class DeleteProductCommand(string id) : IRequest<bool>
{
    /// <summary>
    /// Gets or sets a product identifier.
    /// </summary>
    public string Id { get; set; } = id;
}