using Discount.Grpc.Protos;

namespace Basket.Application.GrpcServices;

/// <summary>
/// Represents a discount service.
/// </summary>
public class DiscountGrpcService
{
    private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoServiceClient;

    public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoServiceClient)
	{
        _discountProtoServiceClient = discountProtoServiceClient;
    }

    /// <summary>
    /// Gets a discount.
    /// </summary>
    /// <param name="productName">Product name.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public async Task<CouponModel> GetDiscountAsync(string productName)
    {
        var discountRequest = new GetDiscountRequest { ProductName = productName };
        return await _discountProtoServiceClient.GetDiscountAsync(discountRequest);
    }
}