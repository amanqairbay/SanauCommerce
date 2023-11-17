using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Exceptions;
using Ordering.Domain.Entities;

namespace Ordering.Application.Features.Orders.Commands.DeleteOrder;

/// <summary>
/// Represents a command handler.
/// </summary>
public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Unit>
{
    private readonly ILogger<DeleteOrderCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;

    public DeleteOrderCommandHandler(
        ILogger<DeleteOrderCommandHandler> logger,
        IMapper mapper,
        IOrderRepository orderRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    }

    /// <summary>
    /// Handles a request.
    /// </summary>
    /// <param name="command">Represents the command to delete an order.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    //// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="NotFoundException">Thrown, if the order to delete is null.</exception>
    public async Task<Unit> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
    {
        var orderToDelete = await _orderRepository.GetByIdAsync(command.Id) ?? throw new NotFoundException(nameof(Order), command.Id);

        await _orderRepository.DeleteAsync(orderToDelete);

        _logger.LogInformation($"Order {orderToDelete.Id} is successfully deleted.");

        return Unit.Value;
    }
}