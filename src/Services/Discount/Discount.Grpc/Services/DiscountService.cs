using AutoMapper;
using Discount.Grpc.Entities;
using Discount.Grpc.Protos;
using Discount.Grpc.Repositories;
using Grpc.Core;

namespace Discount.Grpc.Services;

/// <summary>
/// Represents a gRPC discount service.
/// </summary>
public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
{
    private readonly IDiscountRepository _discountRepository;
    private readonly ILogger<DiscountService> _logger;
    private readonly IMapper _mapper;

    public DiscountService(
        IDiscountRepository discountRepository, 
        ILogger<DiscountService> logger, 
        IMapper mapper)
    {
        _discountRepository = discountRepository;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Gets a discount.
    /// </summary>
    /// <param name="request">Get discount request.</param>
    /// <param name="context">Context for a server-side call.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var coupon = await _discountRepository.GetDiscountAsync(request.ProductName);
        
        _logger.LogInformation($"Discount is retrieved for ProductName #: {coupon.ProductName}, Amount: {coupon.Amount}");

        if (coupon == null)
            throw new RpcException(new Status(StatusCode.NotFound, $"Discount with ProductName = {request.ProductName}"));
    
        _logger.LogInformation($"Discount is retrieved for ProductName: {coupon.ProductName}, Amount: {coupon.Amount}");

        return _mapper.Map<CouponModel>(coupon);
    }

    /// <summary>
    /// Creates a discount.
    /// </summary>
    /// <param name="request">Create discount request.</param>
    /// <param name="context">Context for a server-side call.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var coupon = _mapper.Map<Coupon>(request.Coupon);

        await _discountRepository.CreateDiscountAsync(coupon);

        _logger.LogInformation($"Discount is successfully created. ProductName: {coupon.ProductName}, Amount: {coupon.Amount}");

        return _mapper.Map<CouponModel>(coupon);
    }

    /// <summary>
    /// Updates a discount.
    /// </summary>
    /// <param name="request">Update discount request.</param>
    /// <param name="context">Context for a server-side call.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var coupon = _mapper.Map<Coupon>(request.Coupon);

        await _discountRepository.UpdateDiscountAsync(coupon);

        _logger.LogInformation($"Discount is successfully updated. ProductName: {coupon.ProductName}, Amount: {coupon.Amount}");

        return _mapper.Map<CouponModel>(coupon);
    }

    /// <summary>
    /// Deletes a discount.
    /// </summary>
    /// <param name="request">Delete discount request.</param>
    /// <param name="context">Context for a server-side call.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        var deleted = await _discountRepository.DeleteDiscountAsync(request.ProductName);

        return new DeleteDiscountResponse()
        {
            Success = deleted
        };
    }
}