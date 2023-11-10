using System.Net;
using Discount.API.Entities;
using Discount.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Controllers;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/[controller]")]
public class DiscountController : ControllerBase
{
    private readonly IDiscountRepository _discountRepository;

    public DiscountController(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository ?? throw new ArgumentNullException(nameof(discountRepository));
    }

    [HttpGet("{productName}", Name = "GetDiscount")]
    [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Coupon>> GetDiscountAsync(string productName)
    {
        var discount = await _discountRepository.GetDiscountAsync(productName);
        return Ok(discount);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Coupon), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Coupon>> CreateDiscountAsync([FromBody] Coupon coupon)
    {
        await _discountRepository.CreateDiscountAsync(coupon);
        return CreatedAtRoute("GetDiscount", new { productName = coupon.ProductName}, coupon);
    }

    [HttpPut]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> UpdateDiscountAsync([FromBody] Coupon coupon)
    {
        return Ok(await _discountRepository.UpdateDiscountAsync(coupon));
    }

    [HttpDelete("{productName}", Name = "DeleteDiscount")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<bool>> DeleteDiscountAsync(string productName)
    {
        return Ok(await _discountRepository.DeleteDiscountAsync(productName));
    }
}