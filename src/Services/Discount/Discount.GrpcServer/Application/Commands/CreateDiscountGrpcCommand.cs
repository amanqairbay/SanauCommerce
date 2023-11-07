using AutoMapper;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using Discount.GrpcServer.Protos;
using MediatR;

namespace Discount.GrpcServer.Application.Commands;

/// <summary>
/// Represents a create discount command.
/// </summary>
public class CreateDiscountGrpcCommand : IRequest<CouponModel>
{
    /// <summary>
    /// Gets or sets a product name.
    /// </summary>
    public string ProductName { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets a description.
    /// </summary>
    public string Description { get; set; } = String.Empty;

    /// <summary>
    /// Gets or sets an amount.
    /// </summary>
    public int Amount { get; set; }

    #region nested class CreateDiscountGrpcHandler

    /// <summary>
    /// Represents a handler for creating a discount.
    /// </summary>
    public class CreateDiscountGrpcHandler : IRequestHandler<CreateDiscountGrpcCommand, CouponModel>
    {
        private readonly IMapper _mapper;
        private readonly IDiscountRepository _discountRepository;

        public CreateDiscountGrpcHandler(IMapper mapper, IDiscountRepository discountRepository)
        {
            _mapper = mapper;
            _discountRepository = discountRepository;
        }

        /// <summary>
        /// Handles a command.
        /// </summary>
        /// <param name="command">Command for creating a discount.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        public async Task<CouponModel> Handle(CreateDiscountGrpcCommand command, CancellationToken cancellationToken)
        {
            var coupon = _mapper.Map<Coupon>(command);

            await _discountRepository.CreateDiscountAsync(coupon);

            var couponModel = _mapper.Map<CouponModel>(coupon);

            return couponModel;
        }
    }

    #endregion nested class CreateDiscountGrpcHandler
}
