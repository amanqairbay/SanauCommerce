using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Core.Services;
using MediatR;

namespace Catalog.Application.Features.ProductFeatures.Commands.UpdateProduct;

/// <summary>
/// Represents a product create handler.
/// </summary>
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResponse>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public CreateProductCommandHandler(IFileService fileService, IMapper mapper, IRepositoryManager repository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    /// <summary>
    /// Handles a command.
    /// </summary>
    /// <param name="command">Command for product create.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product.
    /// </returns>
    /// <exception cref="BadRequestException">Thrown when a product cannot be created.</exception>
    public async Task<ProductResponse> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(command)
            ?? throw new BadRequestException("There is an issue mapping while creating new product.");

        var createdProduct = await _repository.Product.CreateAsync(product);
        var productResponse = _mapper.Map<ProductResponse>(createdProduct);

        return productResponse;
    }
}