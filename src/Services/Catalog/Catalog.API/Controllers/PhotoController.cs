using Catalog.Application.Features.ProductImageFeatures.Commands.CreateProductImage;
using Catalog.Application.Features.ProductImageFeatures.Queries.GetProductImage;
using Catalog.Application.Features.ProductImageFeatures.Queries.GetProductImageByName;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

public class PhotoController : ApiController
{
    private readonly IMediator _mediator;

    public PhotoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}", Name = "GetProductImageById")]
    public async Task<IActionResult> GetPhotoById(string id)
    {
        var photoResponse = await _mediator.Send(new GetProductImageQuery(id));

        return File(photoResponse.Buffer, photoResponse.FileExtension);
    }

    [HttpGet("productPhoto/{name}")]
    public async Task<IActionResult> GetProductImageByNameAsync(string name)
    {
        var productImage = await _mediator.Send(new GetProductImageByNameQuery(name));

        return Ok(productImage);
    }

    [HttpPost("productPhotoCreate")]
    public async Task<IActionResult> CreateProductImageAsync([FromForm] CreateProductImageCommand command)
    {
        var productImageResponse = await _mediator.Send(command);

        return CreatedAtRoute("GetProductImageByName", new { name = productImageResponse.Name });
    }
}