using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Core.Services;
using MediatR;

namespace Catalog.Application.Features.ProductImageFeatures.Commands.CreateProductImage;

/// <summary>
/// Represents a product create handler.
/// </summary>
public class CreateProductImageCommandHandler : IRequestHandler<CreateProductImageCommand, ProductImageResponse>
{
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public CreateProductImageCommandHandler(IFileService fileService, IMapper mapper, IRepositoryManager repository)
    {
        _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

     /// <summary>
    /// Handles a command.
    /// </summary>
    /// <param name="command">Command for product image create.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product image.
    /// </returns>
    /// /// <exception cref="BadRequestException">Thrown when a product image cannot be created.</exception>
    public async Task<ProductImageResponse> Handle(CreateProductImageCommand command, CancellationToken cancellationToken)
    {
        if (command.FormFile is null)
        {
            throw new BadRequestException("Upload Failure. No files to upload.");
        }

        var fileSaveResult = _fileService.SaveImage(command.FormFile, command.Name);

        if (fileSaveResult.Item1 is not true)
        {
            throw new BadRequestException(message: fileSaveResult.Item2);
        }

        var productFromDb = await _repository.Product.GetByIdAsync(command.ProductId) 
            ?? throw new BadRequestException($"The product with {command.Id} doesn't exists in the database."); 

        var newProductImage = new ProductImage
        {
            Name = fileSaveResult.Item2,
            IsMain = command.IsMain,
            ProductId = command.ProductId
        };

        // var productImage = _mapper.Map<ProductImage>(command) ?? throw new BadRequestException("There is an issue mapping while creating new product image.");

        var createdProductImage = await _repository.ProductImage.CreateAsync(newProductImage);
        var productImageResponse = _mapper.Map<ProductImageResponse>(createdProductImage);

        return productImageResponse;
    }
}