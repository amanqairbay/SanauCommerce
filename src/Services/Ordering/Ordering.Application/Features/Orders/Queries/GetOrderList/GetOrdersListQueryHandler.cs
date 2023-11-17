using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Persistence;

namespace Ordering.Application.Features.Orders.Queries.GetOrderList;

/// <summary>
/// Represents a handler for a request.
/// </summary>
public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrdersVm>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrdersListQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    /// <summary>
    /// Handles a request.
    /// </summary>
    /// <param name="request">Represents a get list of orders query.</param>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    //// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the orders view model.
    /// </returns>
    public async Task<List<OrdersVm>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
    {
        var orderList = await _orderRepository.GetOrdersByUserName(request.UserName);
        return _mapper.Map<List<OrdersVm>>(orderList);
    }
}