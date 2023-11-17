using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Persistence;
using Ordering.Domain.Entities;
using Ordering.Infrastructure.Persistence;

namespace Ordering.Infrastructure.Repositories;

/// <summary>
/// Represents an order repository.
/// </summary>
public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(OrderContext dbContext) : base(dbContext) { }

    /// <summary>
    /// Gets an order by username.
    /// </summary>
    /// <param name="username">Username.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the list of orders.
    /// </returns>
    public async Task<IEnumerable<Order>> GetOrdersByUserName(string username)
    {
        var orderList = await _dbContext.Orders
                            .Where(o => o.UserName == username)
                            .ToListAsync();
        return orderList;
    }
}