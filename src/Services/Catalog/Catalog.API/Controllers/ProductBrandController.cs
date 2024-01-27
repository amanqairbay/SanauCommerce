using System.Net;
using Catalog.Application.Features.ProductBrandFeatures.Queries.GetProductBrandById;
using Catalog.Application.Features.ProductBrandFeatures.Queries.GetProductBrandList;
using Catalog.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;
public class ProductBrandController : ApiController
{
    private readonly IMediator _mediator;

    public ProductBrandController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/v1/[controller]/list
    [HttpGet("list")]
    [ProducesResponseType(typeof(IReadOnlyList<ProductBrandResponse>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductBrandsAsync()
    {
        var productBrands = await _mediator.Send(new GetProductBrandsQuery());
        
        return Ok(productBrands);
    }

    // GET: api/v1/[controller]/id
    [HttpGet("{id:length(24)}", Name = "GetBrandById")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ProductBrandResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductBrandByIdAsync(string id)
    {
        var productBrand = await _mediator.Send(new GetProductBrandByIdQuery(id));
        
        return Ok(productBrand);
    }
}