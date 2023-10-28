using System.Net;
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

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<ProductResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetProductsAsync()
    {
        var products = await _mediator.Send(new GetProductsQuery());
        
        return Ok(products);
    }

    [HttpGet("paged")]
    [ProducesResponseType(typeof(ProductResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult> GetPagedProductsAsync([FromQuery] ProductParameters productParams)
    {
        var pagedProducts = await _mediator.Send(productParams);

        return Ok(pagedProducts);
    }
}