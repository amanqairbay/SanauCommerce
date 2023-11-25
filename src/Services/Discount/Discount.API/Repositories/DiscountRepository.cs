using Dapper;
using Discount.API.Entities;
using Discount.API.Repositories;
using Npgsql;

namespace Discount.Infrastructure.Repositories;

/// <summary>
/// Represents a discount repository.
/// </summary>
public class DiscountRepository : IDiscountRepository
{
    private readonly IConfiguration _configuration;
    private readonly string? _connectionString;

    public DiscountRepository(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _connectionString = _configuration.GetValue<string>("DatabaseSettings:ConnectionString");
    }

    /// <summary>
    /// Gets a discount.
    /// </summary>
    /// <param name="productName">Product name.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the discount.
    /// </returns>
    public async Task<Coupon> GetDiscountAsync(string productName)
    {
        await using var connection = new NpgsqlConnection(_connectionString);

        var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>("SELECT * FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName });

        return coupon ?? new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount Available" };
    }

    /// <summary>
    /// Creates a discount.
    /// </summary>
    /// <param name="coupon">Coupon.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    public async Task<bool> CreateDiscountAsync(Coupon coupon)
    {
        await using var connection = new NpgsqlConnection(_connectionString);

        var affected = await connection.ExecuteAsync("INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)",
            new Coupon { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });

        if (affected == 0)
            return false;

        return true;
    }

    /// <summary>
    /// Updates a discount.
    /// </summary>
    /// <param name="coupon">Coupon.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    public async Task<bool> UpdateDiscountAsync(Coupon coupon)
    {
        await using var connection = new NpgsqlConnection(_connectionString);

        var affected = await connection.ExecuteAsync("UPDATE Coupon SET ProductName = @ProductName, Description = @Description, Amount = @Amount WHERE Id = @Id",
            new Coupon { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount, Id = coupon.Id });

        if (affected == 0)
            return false;

        return true;
    }

    /// <summary>
    /// Deletes a discount.
    /// </summary>
    /// <param name="productName">Product name.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// </returns>
    public async Task<bool> DeleteDiscountAsync(string productName)
    {
        await using var connection = new NpgsqlConnection(_connectionString);

        var affected = await connection.ExecuteAsync("DELETE FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName });

        if (affected == 0)
            return false;

        return true;
    }
}