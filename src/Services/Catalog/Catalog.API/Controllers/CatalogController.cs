using System.Net;
using Catalog.Application.Commands;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.RequestFeatures;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

public class CatalogController : ApiController
{
    private readonly IMediator _mediator;

    public CatalogController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/v1/[controller]/products
    [HttpGet("products")]
    [ProducesResponseType(typeof(IReadOnlyList<ProductResponse>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductsAsync()
    {
        var products = await _mediator.Send(new GetProductsQuery());
        
        return Ok(products);
    }

    // GET: api/v1/[controller]/pagedProducts
    [HttpGet("pagedProducts")]
    [ProducesResponseType(typeof(Pagination<ProductResponse>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetPagedProductsAsync([FromQuery] ProductParameters productParams)
    {
        var pagedProducts = await _mediator.Send(new GetPagedProductsQuery(productParams));

        return Ok(pagedProducts);
    }

    // GET: api/v1/[controller]/products/id
    [HttpGet("products/{id:length(24)}", Name = "GetProductById")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductByIdAsync(string id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));
        
        return Ok(product);
    }

    // GET: api/v1/[controller]/products/name
    [HttpGet("products/{name}", Name = "GetProductByName")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductByNameAsync(string name)
    {
        var product = await _mediator.Send(new GetProductByNameQuery(name));
        
        return Ok(product);
    }

    // POST: api/v1/[controller]/products
    [HttpPost("products")]
    [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductCommand command)
    {
        var productResponse = await _mediator.Send(command);

        return CreatedAtRoute("GetProductById", new { id = productResponse.Id }, productResponse);
    }

    // PUT: api/v1/[controller]/products
    [HttpPut("products")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateProductAsync([FromBody] UpdateProductCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    // DELETE: api/v1/[controller]/products/id
    [HttpDelete("products/{id:length(24)}", Name = "DeleteProduct")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteProductAsync(string id)
    {
        var result = await _mediator.Send(new DeleteProductCommand(id));

        return Ok(result);
    }
}