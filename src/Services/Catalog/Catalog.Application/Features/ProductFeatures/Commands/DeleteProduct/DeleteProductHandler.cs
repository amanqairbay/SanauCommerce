using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.ProductFeatures.Commands.DeleteProduct;

/// <summary>
/// Represents a product delete handler.
/// </summary>
public class DeleteProductHandler(IRepositoryManager repository) : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IRepositoryManager _repository = repository ?? throw new ArgumentNullException(nameof(repository));

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
        await _repository.Product.DeleteAsync(command.Id);
}