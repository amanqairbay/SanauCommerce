
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Persistence;
using Ordering.Domain.Common;
using Ordering.Infrastructure.Persistence;

namespace Ordering.Infrastructure.Repositories;

/// <summary>
/// Represents a base repository class.
/// </summary>
/// <typeparam name="T"></typeparam>
public class BaseRepository<T> : IAsyncRepository<T> where T : BaseEntity
{
    protected readonly OrderContext _dbContext;

    public BaseRepository(OrderContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    /// <summary>
    /// Gets all entities.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a collection of entities.
    /// </returns>
    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    /// <summary>
    /// Gets entities based on a condition.
    /// </summary>
    /// <param name="predicate">The condition the entities must fulfil to be returned.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a collection of entities.
    /// </returns>
    public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbContext.Set<T>().Where(predicate).ToListAsync();
    }

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
    public async Task<IReadOnlyList<T>> GetAsync(
        Expression<Func<T, bool>> predicate = null, 
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
        string includeString = null, 
        bool disableTracking = true)
    {
        IQueryable<T> query = _dbContext.Set<T>();
    
        if (disableTracking) 
            query = query.AsNoTracking();
        
        if (!string.IsNullOrWhiteSpace(includeString)) 
            query = query.Include(includeString);

        if (predicate != null) 
            query = query.Where(predicate);

        if (orderBy != null)
            return await orderBy(query).ToListAsync();
            
        return await query.ToListAsync();
    }

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
    public async Task<IReadOnlyList<T>> GetAsync(
        Expression<Func<T, bool>> predicate = null, 
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
        List<Expression<Func<T, object>>> includes = null, 
        bool disableTracking = true)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        
        if (disableTracking) 
            query = query.AsNoTracking();

        if (includes != null) 
            query = includes.Aggregate(query, (current, include) => current.Include(include));

        if (predicate != null) 
            query = query.Where(predicate);

        if (orderBy != null)
            return await orderBy(query).ToListAsync();

        return await query.ToListAsync();
    }

    /// <summary>
    /// Gets an entity by identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity to retrieve.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the entity.
    /// </returns>
    public virtual async Task<T> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    /// <summary>
    /// Adds an entity.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    //// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the that entity was added.
    /// </returns>
    public async Task<T> AddAsync(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    /// <summary>
    /// Updates an entity.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes an entity.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}