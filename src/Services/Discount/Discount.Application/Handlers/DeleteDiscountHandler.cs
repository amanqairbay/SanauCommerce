using Discount.Application.Commands;
using Discount.Core.Repositories;
using MediatR;

namespace Discount.Application.Handlers;

/// <summary>
/// Represents a handler for deleting a discount.
/// </summary>
public class DeleteDiscountHandler : IRequestHandler<DeleteDiscountCommand, bool>
{
    private readonly IDiscountRepository _discountRepository;

    public DeleteDiscountHandler(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }

    /// <summary>
    /// Handles a request.
    /// </summary>
    /// <param name="command">Command for deleting a discount.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    public async Task<bool> Handle(DeleteDiscountCommand command, CancellationToken cancellationToken) =>
        await _discountRepository.DeleteDiscountAsync(command.ProductName);
}