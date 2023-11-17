using System.Linq.Expressions;
using Ordering.Domain.Common;

namespace Ordering.Application.Contracts.Persistence;

/// <summary>
/// Represents an async repository.
/// </summary>
/// <typeparam name="T">Entity type.</typeparam>
public interface IAsyncRepository<T> where T : BaseEntity
{
    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a collection of entities.
    /// </returns>
    Task<IReadOnlyList<T>> GetAllAsync();

    /// <summary>
    /// Gets entities based on a condition.
    /// </summary>
    /// <param name="predicate">The condition the entities must fulfil to be returned.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a collection of entities.
    /// </returns>
    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Gets a collection of entities based on the specified criteria.
    /// </summary>
    /// <param name="predicate">The condition the entities must fulfil to be returned.</param>
    /// <param name="orderBy">The function used to order the entities.</param>
    /// <param name="includeString">Any other navigation properties to include when returning the collection.</param>
    /// <param name="disableTracking">Disable tracking.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a collection of entities.
    /// </returns>
    Task<IReadOnlyList<T>> GetAsync(
        Expression<Func<T, bool>>? predicate = null, 
        Func<IQueryable<T>?, IOrderedQueryable<T>>? orderBy = null,
        string? includeString = null,
        bool disableTracking = true);

    /// <summary>
    /// Gets a collection of entities based on the specified criteria.
    /// </summary>
    /// <param name="predicate">The condition the entities must fulfil to be returned</param>
    /// <param name="orderBy">The function used to order the entities.</param>
    /// <param name="includes">List of entities to include when returning the collection.</param>
    /// <param name="disableTracking">Disable tracking.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a collection of entities.
    /// </returns>
    Task<IReadOnlyList<T>> GetAsync(
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        List<Expression<Func<T, object>>>? includes = null,
        bool disableTracking = true);

    /// <summary>
    /// Gets an entity by identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity to retrieve.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the entity.
    /// </returns>
    Task<T?> GetByIdAsync(int id);

    /// <summary>
    /// Adds an entity.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    //// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the that entity was added.
    /// </returns>
    Task<T> AddAsync(T entity);

    /// <summary>
    /// Updates an entity.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task UpdateAsync(T entity);

    /// <summary>
    /// Deletes an entity.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task DeleteAsync(T entity);
}