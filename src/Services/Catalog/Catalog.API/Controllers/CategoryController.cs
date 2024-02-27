using System.Net;
using Catalog.Application.Features.Categories.Querie.GetCategoryList;
using Catalog.Application.Features.Categories.Queries.GetCategoryById;
using Catalog.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;
public class CategoryController : ApiController
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/v1/[controller]/list
    [HttpGet("list")]
    [ProducesResponseType(typeof(IReadOnlyList<CategoryResponse>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCategoriesAsync()
    {
        var productTypes = await _mediator.Send(new GetCategoriesQuery());
        
        return Ok(productTypes);
    }

    // GET: api/v1/[controller]/id
    [HttpGet("{id:length(24)}", Name = "GetCategoryById")]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(CategoryResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCategoryByIdAsync(string id)
    {
        var productType = await _mediator.Send(new GetCategoryByIdQuery(id));
        
        return Ok(productType);
    }
}