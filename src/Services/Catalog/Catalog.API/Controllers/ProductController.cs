using System.Net;
using Microsoft.AspNetCore.Mvc;
using Catalog.Application.Responses;
using Catalog.Core.RequestFeatures;
using MediatR;
using Catalog.Application.Features.Products.Commands.CreateProduct;
using Catalog.Application.Features.Products.Commands.DeleteProduct;
using Catalog.Application.Features.Products.Commands.UpdateProduct;
using Catalog.Application.Features.Products.Queries.GetProductById;
using Catalog.Application.Features.Products.Queries.GetProductByName;
using Catalog.Application.Features.Products.Queries.GetProductBySeName;
using Catalog.Application.Features.Products.Queries.GetProductByCategory;
using Catalog.Application.Features.Products.Queries.GetProductPagedList;
using Catalog.Application.Features.Products.Queries.GetProductList;
using Microsoft.AspNetCore.Authorization;

namespace Catalog.API.Controllers;

[Authorize]
public class ProductController : ApiController
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/v1/[controller]/list
    [HttpGet("list")]
    [ProducesResponseType(typeof(IReadOnlyList<ProductResponse>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductsAsync()
    {
        var products = await _mediator.Send(new GetProductsQuery());
        
        return Ok(products);
    }

    // GET: api/v1/[controller]/pagedList
    [HttpGet("pagedList")]
    [ProducesResponseType(typeof(Pagination<ProductResponse>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetPagedProductsAsync([FromQuery] ProductParameters productParams)
    {
        var pagedProducts = await _mediator.Send(new GetPagedProductsQuery(productParams));

        return Ok(pagedProducts);
    }

    // GET: api/v1/[controller]/id
    [HttpGet("{id:length(24)}", Name = "GetById")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductByIdAsync(string id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));
        
        return Ok(product);
    }

    // GET: api/v1/[controller]/name/{name}
    [HttpGet("name/{name:minlength(1)}", Name = "GetByName")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductByNameAsync(string name)
    {
        var product = await _mediator.Send(new GetProductByNameQuery(name));
        
        return Ok(product);
    }

    // GET: api/v1/[controller]/name/{name}
    [HttpGet("seName/{seName:minlength(1)}", Name = "GetBySeName")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductBySeNameAsync(string seName)
    {
        var product = await _mediator.Send(new GetProductBySeNameQuery(seName));
        
        return Ok(product);
    }

    // GET: api/v1/[controller]/type/{type}
    [HttpGet("category/{categoryId:minlength(1)}", Name = "GetByCategory")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductByCategoryAsync(string categoryId)
    {
        var products = await _mediator.Send(new GetProductByCategoryQuery(categoryId));
        
        return Ok(products);
    }

    // POST: api/v1/[controller]/create
    //[Authorize("ClientIdPolicy")]
    [HttpPost("create")]
    [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductCommand command)
    {
        var productResponse = await _mediator.Send(command);

        return CreatedAtRoute("GetById", new { id = productResponse.Id }, productResponse);
    }

    // PUT: api/v1/[controller]/update
    //[Authorize("ClientIdPolicy")]
    [HttpPut("update")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateProductAsync([FromBody] UpdateProductCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    // DELETE: api/v1/[controller]/delete/id
    //[Authorize("ClientIdPolicy")]
    [HttpDelete("delete/{id:length(24)}", Name = "DeleteProduct")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteProductAsync(string id)
    {
        var result = await _mediator.Send(new DeleteProductCommand(id));

        return Ok(result);
    }
}