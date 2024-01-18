using Catalog.Application.Features.ProductImageFeatures.Commands.CreateProductImage;
using Catalog.Application.Features.ProductImageFeatures.Queries.GetProductImage;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

public class PhotoController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IWebHostEnvironment _env;

    public PhotoController(IMediator mediator, IWebHostEnvironment env)
    {
        _mediator = mediator;
        _env = env;
    }

    [HttpGet("{name}", Name = "GetProductImageByName")]
    public async Task<IActionResult> GetPhotoById(string name)
    {
        var productImage = await _mediator.Send(new GetProductImageQuery(name));

        if (productImage != null)
        {
            var webRoot = _env.WebRootPath;
            var path = Path.Combine(webRoot, $"img{Path.DirectorySeparatorChar}product-card/" + productImage.Name);

            string imageFileExtension = Path.GetExtension(productImage.Name);

            var buffer = await System.IO.File.ReadAllBytesAsync(path);

            return File(buffer, "image/png");
        }

        return NotFound();
    }

    [HttpGet("productPhoto/{name}")]
    public async Task<IActionResult> GetProductImageByNameAsync(string name)
    {
        var productImage = await _mediator.Send(new GetProductImageQuery(name));

        return Ok(productImage);
    }

    [HttpPost("productPhotoCreate")]
    public async Task<IActionResult> CreateProductImageAsync([FromForm] CreateProductImageCommand command)
    {
        var productImageResponse = await _mediator.Send(command);

        return CreatedAtRoute("GetProductImageByName", new { name = productImageResponse.Name });
    }
}