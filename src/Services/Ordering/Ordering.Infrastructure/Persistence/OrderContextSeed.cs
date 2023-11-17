using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence;

public class OrderContextSeed
{
    public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
    {            
        if (!orderContext.Orders.Any())
        {
            orderContext.Orders.AddRange(GetPreconfiguredOrders());
            await orderContext.SaveChangesAsync();
            logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
        }
    }

    private static IEnumerable<Order> GetPreconfiguredOrders()
    {
        return new List<Order>
        {
            new Order() 
            {
                UserName = "Aman",
                FirstName = "Aman",
                LastName = "Qairbay",
                EmailAddress = "amanqairbay@gmail.com",
                AddressLine = "Zhanaozen",
                Country = "Kazakhstan",
                TotalPrice = 750,
                State = "Mangistau",
                ZipCode = "130200",

                CardName = "Visa",
                CardNumber = "1234567890123456",
                CreatedBy = "Aman",
                Expiration = "12/25",
                CVV = "123",
                PaymentMethod = 1,
                LastModifiedBy = "Aman",
                LastModifiedDate = new DateTime(),
            }
        };
    }
}