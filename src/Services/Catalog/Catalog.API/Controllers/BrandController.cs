using System.Net;
using Catalog.Application.Features.Brands.Queries.GetBrandById;
using Catalog.Application.Features.Brands.Queries.GetBrandList;
using Catalog.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;
public class BrandController : ApiController
{
    private readonly IMediator _mediator;

    public BrandController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/v1/[controller]/list
    [HttpGet("list")]
    [ProducesResponseType(typeof(IReadOnlyList<BrandResponse>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBrandsAsync()
    {
        var brands = await _mediator.Send(new GetBrandsQuery());
        
        return Ok(brands);
    }

    // GET: api/v1/[controller]/id
    [HttpGet("{id:length(24)}", Name = "GetBrandById")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(BrandResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductBrandByIdAsync(string id)
    {
        var brand = await _mediator.Send(new GetBrandByIdQuery(id));
        
        return Ok(brand);
    }
}