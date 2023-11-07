using AutoMapper;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using Discount.GrpcServer.Protos;
using MediatR;

namespace Discount.GrpcServer.Application.Commands;

/// <summary>
/// Represents a command for updating a discount.
/// </summary>
public class UpdateDiscountGrpcCommand : IRequest<CouponModel>
{
    /// <summary>
    /// Gets or sets an identifier.
    /// </summary>
    public int Id { get; set; }

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

    #region nested class UpdateDiscountGrpcHandler

    /// <summary>
    /// Represents a handler for updating a discount.
    /// </summary>
    public class UpdateDiscountGrpcHandler : IRequestHandler<UpdateDiscountGrpcCommand, CouponModel>
    {
        private readonly IMapper _mapper;
        private readonly IDiscountRepository _discountRepository;

        public UpdateDiscountGrpcHandler(IMapper mapper, IDiscountRepository discountRepository)
        {
            _mapper = mapper;
            _discountRepository = discountRepository;
        }

        /// <summary>
        /// Handles a command.
        /// </summary>
        /// <param name="command">Command for updating a discount.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        public async Task<CouponModel> Handle(UpdateDiscountGrpcCommand command, CancellationToken cancellationToken)
        {
            var coupon = _mapper.Map<Coupon>(command);

            await _discountRepository.UpdateDiscountAsync(coupon);

            var couponResponse = _mapper.Map<CouponModel>(coupon);

            return couponResponse;
        }
    }

    #endregion nested class UpdateDiscountGrpcHandler
}