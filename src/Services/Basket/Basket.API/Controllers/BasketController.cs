using System.Net;
using Basket.Application.Commands;
using Basket.Application.Queries;
using Basket.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers;

public class BasketController : ApiController
{
    private readonly IMediator _mediator;

    public BasketController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/v{version:apiVersion}/[controller]/username
    [HttpGet("{username}")]
    [ProducesResponseType(typeof(ShoppingCartResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBasketAsync(string username)
    {
        var basket = await _mediator.Send(new GetBasketQuery(username));

        return Ok(basket ?? new ShoppingCartResponse(username));
    }

    // POST: api/v{version:apiVersion}/[controller]
    [HttpPost]
    [ProducesResponseType(typeof(ShoppingCartResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingCartResponse>> UpdateBasketAsync([FromBody] CreateBasketCommand command)
    {
        var basket = await _mediator.Send(command);

        return Ok(basket);
    }

    // DELETE: api/v{version:apiVersion}/[controller]/username
    [HttpDelete("{userName}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<ShoppingCartResponse>> DeleteBasketAsync(string username)
    {
        return Ok(await _mediator.Send(new DeleteBasketCommand(username)));
    }
}