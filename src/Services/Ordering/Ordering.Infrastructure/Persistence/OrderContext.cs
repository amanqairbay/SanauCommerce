using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Common;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence;

/// <summary>
/// Represents a session with the database and can be used to query and save instances of your entities.
/// </summary>
public class OrderContext : DbContext
{
    /// <summary>
    /// Gets or sets the orders.
    /// A DbSet can be used to query and save instances of Order. 
    /// LINQ queries against a DbSet will be translated into queries against the database.
    /// </summary>
    public DbSet<Order> Orders { get; set; }

    /// <summary>
    /// Initializes a new instance of the DbContext class using the specified options. 
    /// The DbContext.OnConfiguring(DbContextOptionsBuilder) method will still be called to allow further configuration of the options.
    /// </summary>
    /// <param name="options">
    /// The options to be used by a DbContext. You normally override DbContext.OnConfiguring(DbContextOptionsBuilder)
    /// or use a DbContextOptionsBuilder to create instances of this class 
    /// and it is not designed to be directly constructed in your application code.
    /// </param>
    public OrderContext(DbContextOptions<OrderContext> options) : base(options) { }

    
    /// <summary>
    /// Saves all changes made in this context to the database.
    /// </summary>
    /// <param name="cancellationToken">Propagates notification that operations should be canceled.</param>
    /// <returns>
    /// A task that represents the asynchronous save operation. 
    /// The task result contains the number of state entries written to the database.
    /// </returns>
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.CreatedBy = "Aman";
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    entry.Entity.LastModifiedBy = "Aman";
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}