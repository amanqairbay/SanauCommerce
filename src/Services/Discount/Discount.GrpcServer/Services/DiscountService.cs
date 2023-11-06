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

    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var couponModel = await _mediator.Send(new GetDiscountGrpcQuery(request.ProductName));

        _logger.LogInformation($"Discount is retrieved for the Product Name: {couponModel.ProductName} and Amount : {couponModel.Amount}");

        return couponModel;
    }
}