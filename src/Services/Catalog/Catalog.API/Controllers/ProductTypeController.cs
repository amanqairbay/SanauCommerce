using System.Net;
using Catalog.Application.Features.ProductTypeFeatures.Querie.GetProductTypeList;
using Catalog.Application.Features.ProductTypeFeatures.Queries.GetProductTypeById;
using Catalog.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;
public class ProductTypeController : ApiController
{
    private readonly IMediator _mediator;

    public ProductTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/v1/[controller]/list
    [HttpGet("list")]
    [ProducesResponseType(typeof(IReadOnlyList<ProductTypeResponse>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductTypesAsync()
    {
        var productTypes = await _mediator.Send(new GetProductTypesQuery());
        
        return Ok(productTypes);
    }

    // GET: api/v1/[controller]/id
    [HttpGet("{id:length(24)}", Name = "GetTypeById")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(ProductTypeResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProductTypeByIdAsync(string id)
    {
        var productType = await _mediator.Send(new GetProductTypeByIdQuery(id));
        
        return Ok(productType);
    }
}