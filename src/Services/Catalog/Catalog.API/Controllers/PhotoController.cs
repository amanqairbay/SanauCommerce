using Catalog.Application.Features.Photos.Commands.CreatePhoto;
using Catalog.Application.Features.Photos.Queries.GetPhotoById;
using Catalog.Application.Features.Photos.Queries.GetPhotoByName;
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

    [HttpGet("{id}", Name = "GetPhotoById")]
    public async Task<IActionResult> GetPhotoById(string id)
    {
        var photoResponse = await _mediator.Send(new GetPhotoByIdQuery(id));

        return File(photoResponse.Buffer, photoResponse.FileExtension);
    }

    [HttpGet("productPhoto/{name}")]
    public async Task<IActionResult> GetPhotoByNameAsync(string name)
    {
        var productImage = await _mediator.Send(new GetPhotoByNameQuery(name));

        return Ok(productImage);
    }

    [HttpPost("productPhotoCreate")]
    public async Task<IActionResult> CreateProductImageAsync([FromForm] CreatePhotoCommand command)
    {
        var photoResponse = await _mediator.Send(command);

        return CreatedAtRoute("GetProductImageByName", new { name = photoResponse.Name });
    }
}