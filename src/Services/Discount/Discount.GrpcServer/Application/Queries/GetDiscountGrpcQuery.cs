using AutoMapper;
using Discount.Core.Repositories;
using Discount.GrpcServer.Protos;
using Grpc.Core;
using MediatR;

namespace Discount.GrpcServer.Application.Queries;

/// <summary>
/// Represents a request for getting a discount.
/// </summary>
public class GetDiscountGrpcQuery : IRequest<CouponModel>
{
    /// <summary>
    /// Gets or sets a product name.
    /// </summary>
    public string ProductName { get; set; }

    public GetDiscountGrpcQuery(string productName)
    {
        ProductName = productName;
    }

    #region nested class CreateDiscountGrpcHandler

    /// <summary>
    /// Represents a get discount handler.
    /// </summary>
    public class GetDiscountGrpcQueryHandler : IRequestHandler<GetDiscountGrpcQuery, CouponModel>
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;

        public GetDiscountGrpcQueryHandler(IDiscountRepository discountRepository, IMapper mapper)
        {
            _discountRepository = discountRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles a request.
        /// </summary>
        /// <param name="request">Request for getting a discount.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        public async Task<CouponModel> Handle(GetDiscountGrpcQuery request, CancellationToken cancellationToken)
        {
            var coupon = await _discountRepository.GetDiscountAsync(request.ProductName);

            if (coupon is null)
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with the product name = {request.ProductName} not found."));

            var couponModel = _mapper.Map<CouponModel>(coupon);

            return couponModel;
        }
    }

    #endregion nested class CreateDiscountGrpcHandler
}