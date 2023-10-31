using Catalog.Application.Commands;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

/// <summary>
/// Represents a product delete handler.
/// </summary>
public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductHandler(IProductRepository productRepository) => _productRepository = productRepository;

    /// <summary>
    /// Handles a command.
    /// </summary>
    /// <param name="command">Command for product delete.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the delete result.
    /// </returns>
    public async Task<bool> Handle(DeleteProductCommand command, CancellationToken cancellationToken) =>
        await _productRepository.DeleteProductAsync(command.Id);
}