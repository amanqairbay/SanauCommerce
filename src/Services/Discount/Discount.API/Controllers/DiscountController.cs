using System.Net;
using Discount.Application.Commands;
using Discount.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Discount.Application.Responses;

namespace Discount.API.Controllers;

public class DiscountController : ApiController
{
    private readonly IMediator _mediator;

    public DiscountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/v1/[controller]/productName
    [HttpGet("{productName}", Name = "GetDiscount")]
    [ProducesResponseType(typeof(CouponResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CouponResponse>> GetDiscountAsync(string productName)
    {
        var couponResponse = await _mediator.Send(new GetDiscountQuery(productName));
        
        return Ok(couponResponse);
    }

    // POST: api/v1/[controller]
    [HttpPost]
    [ProducesResponseType(typeof(CouponResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CouponResponse>> CreateDiscountAsync([FromBody] CreateDiscountCommand command)
    {
        var couponResponse = await _mediator.Send(command);

        return CreatedAtRoute("GetDiscount", new { productName = couponResponse.ProductName }, couponResponse);
    }

    // PUT: api/v1/[controller]
    [HttpPut]
    [ProducesResponseType(typeof(CouponResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CouponResponse>> UpdateDiscountAsync([FromBody] UpdateDiscountCommand command)
    {
        var couponResponse = await _mediator.Send(command);

        return Ok(couponResponse);
    }

    // DELETE: api/v1/[controller]/productName
    [HttpDelete("{productName}")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteProductAsync(string productName)
    {
        var result = await _mediator.Send(new DeleteDiscountCommand(productName));

        return Ok(result);
    }
}