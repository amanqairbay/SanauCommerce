using System.Net;
using Basket.Application.Commands;
using Basket.Application.Mappers;
using Basket.Application.Queries;
using Basket.Application.Responses;
using Basket.Core.Entities;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers;

public class BasketController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IPublishEndpoint _publishEndpoint;

    public BasketController(IMediator mediator, IPublishEndpoint publishEndpoint)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
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

    // POST: api/v{version:apiVersion}/[controller]/checkout
    [HttpPost("checkout")]
    [ProducesResponseType((int)HttpStatusCode.Accepted)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CheckOutAsync([FromBody] BasketCheckout basketCheckout)
    {
        // get existing basket with total price
        var basket = await _mediator.Send(new GetBasketQuery(basketCheckout.UserName));
        if (basket is null) return BadRequest();

        // create basketCheckoutEvent - set TotalPrice on basketCheckout eventMessage
        var eventMessage = BasketMapper.GetMapper.Map<BasketCheckoutEvent>(basketCheckout);
        eventMessage.TotalPrice = basket.TotalPrice;

        // send checkout event to rabbitmq
        // Publishes a message to all subscribed consumers for the message type as specified by the generic parameter. 
        // The second parameter allows the caller to customize the outgoing publish context and set things like headers on the message.
        await _publishEndpoint.Publish(eventMessage);

        // remove the basket
        await _mediator.Send(new DeleteBasketCommand(basketCheckout.UserName));

        return Accepted();
    }
}