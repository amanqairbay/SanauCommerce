using Discount.Core.Repositories;
using MediatR;

namespace Discount.GrpcServer.Application.Commands;

/// <summary>
/// Represents a command for deleting a discount.
/// </summary>
public class DeleteDiscountGrpcCommand : IRequest<bool>
{
    /// <summary>
    /// Gets or sets a product name.
    /// </summary>
    public string ProductName { get; set; }

    public DeleteDiscountGrpcCommand(string productName)
    {
        ProductName = productName;
    }

    #region nested class DeleteDiscountGrpcHandler
    /// <summary>
    /// Represents a handler for deleting a discount.
    /// </summary>
    public class DeleteDiscountGrpcHandler : IRequestHandler<DeleteDiscountGrpcCommand, bool>
    {
        private readonly IDiscountRepository _discountRepository;

        public DeleteDiscountGrpcHandler(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        /// <summary>
        /// Handles a command.
        /// </summary>
        /// <param name="command">Command for deleting a discount.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        public async Task<bool> Handle(DeleteDiscountGrpcCommand command, CancellationToken cancellationToken) =>
            await _discountRepository.DeleteDiscountAsync(command.ProductName);
    }

    #endregion nested class DeleteDiscountGrpcHandler
}