using MediatR;

namespace Ordering.Application.Features.Orders.Queries.GetOrderList;

/// <summary>
/// Represents a get list of orders query.
/// </summary>
public class GetOrdersListQuery : IRequest<List<OrdersVm>>
{
    /// <summary>
    /// Gets or sets a username.
    /// </summary>
    public string UserName { get; set; }

    public GetOrdersListQuery(string userName)
    {
        UserName = userName ?? throw new ArgumentNullException(nameof(userName));
    }
}