using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Infrastructure;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Models;
using Ordering.Domain.Entities;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrder;

/// <summary>
/// Represents a command handler.
/// </summary>
public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, int>
{
    private readonly IEmailService _emailService;
    private readonly IMapper _mapper;
    private readonly ILogger<CheckoutOrderCommandHandler> _logger;
    private readonly IOrderRepository _orderRepository;

    public CheckoutOrderCommandHandler(
        IEmailService emailService, 
        IMapper mapper, 
        ILogger<CheckoutOrderCommandHandler> logger, 
        IOrderRepository orderRepository)
    {
        _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    }

    /// <summary>
    /// Handles a command.
    /// </summary>
    /// <param name="command">Represents a checkout order command.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    //// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the new order's identifier.
    /// </returns>
    public async Task<int> Handle(CheckoutOrderCommand command, CancellationToken cancellationToken)
    {
        var orderEntity = _mapper.Map<Order>(command);
        var newOrder = await _orderRepository.AddAsync(orderEntity);
            
        _logger.LogInformation($"Order {newOrder.Id} is successfully created.");
            
        await SendMail(newOrder);

        return newOrder.Id;
    }

    /// <summary>
    /// Sends an email.
    /// </summary>
    /// <param name="order">Order entity.</param>
    //// <returns>A task that represents the asynchronous operation.</returns>
    private async Task SendMail(Order order)
    {            
        var email = new Email() 
        { 
            To = "amankhair38@gmail.com", 
            Body = $"Order was created.", 
            Subject = "Order was created" 
        };

        try
        {
            await _emailService.SendEmail(email);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Order {order.Id} failed due to an error with the mail service: {ex.Message}");
        }
    }
}