using Basket.Application.Commands;
using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Handlers;

/// <summary>
/// Represents a delete basket handler.
/// </summary>
public class DeleteBasketHandler : IRequestHandler<DeleteBasketCommand, Unit>
{
	private readonly IBasketRepository _basketRepository;

    public DeleteBasketHandler(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }

    /// <summary>
    /// Handles a command.
    /// </summary>
    /// <param name="command">Command for deleting customer's basket.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    public async Task<Unit> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
    {
        await _basketRepository.DeleteBasketAsync(command.UserName);

        return Unit.Value;
    }
}