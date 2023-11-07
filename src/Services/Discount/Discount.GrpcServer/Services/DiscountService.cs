using Discount.GrpcServer.Application.Commands;
using Discount.GrpcServer.Application.Queries;
using Discount.GrpcServer.Protos;
using Grpc.Core;
using MediatR;

namespace Discount.GrpcServer.Services;

/// <summary>
/// Represents a discount service.
/// </summary>
public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
{
    private readonly ILogger<DiscountService> _logger;
    private readonly IMediator _mediator;

    public DiscountService(ILogger<DiscountService> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public DiscountService(IMediator mediator, ILogger<DiscountService> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    /// <summary>
    /// Gets a discount.
    /// </summary>
    /// <param name="request">Get discount request.</param>
    /// <param name="context">Context for a server-side call.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var couponModel = await _mediator.Send(new GetDiscountGrpcQuery(request.ProductName));

        _logger.LogInformation($"Discount is retrieved for the Product Name: {couponModel.ProductName} and Amount : {couponModel.Amount}");

        return couponModel;
    }

    /// <summary>
    /// Creates a discount.
    /// </summary>
    /// <param name="request">Create discount request.</param>
    /// <param name="context">Context for a server-side call.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var command = new CreateDiscountGrpcCommand
        {
            ProductName = request.Coupon.ProductName,
            Amount = request.Coupon.Amount,
            Description = request.Coupon.Description
        };

        var couponModel = await _mediator.Send(command);
        _logger.LogInformation($"Discount is successfully created for the Product Name: {couponModel.ProductName}");

        return couponModel;
    }

    /// <summary>
    /// Updates a discount.
    /// </summary>
    /// <param name="request">Update discount request.</param>
    /// <param name="context">Context for a server-side call.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var command = new UpdateDiscountGrpcCommand
        {
            Id = request.Coupon.Id,
            ProductName = request.Coupon.ProductName,
            Amount = request.Coupon.Amount,
            Description = request.Coupon.Description
        };

        var couponModel = await _mediator.Send(command);
        _logger.LogInformation($"Discount is successfully updated Product Name: {couponModel.ProductName}");

        return couponModel;
    }

    /// <summary>
    /// Deletes a discount.
    /// </summary>
    /// <param name="request">Delete discount request.</param>
    /// <param name="context">Context for a server-side call.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        var cmd = new DeleteDiscountGrpcCommand(request.ProductName);
        var deleted = await _mediator.Send(cmd);

        var response = new DeleteDiscountResponse
        {
            Success = deleted
        };

        return response;
    }
}