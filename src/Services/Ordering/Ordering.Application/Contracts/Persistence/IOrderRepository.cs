using Ordering.Domain.Entities;

namespace Ordering.Application.Contracts.Persistence;

/// <summary>
/// Represents an order repository.
/// </summary>
public interface IOrderRepository : IAsyncRepository<Order>
{
    /// <summary>
    /// Gets an order by username.
    /// </summary>
    /// <param name="username">Username.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the list of orders.
    /// </returns>
    Task<IEnumerable<Order>> GetOrdersByUserName(string username);
}