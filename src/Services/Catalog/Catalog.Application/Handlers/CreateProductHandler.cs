using Catalog.Application.Commands;
using Catalog.Application.Mappers;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Entities.Exceptions;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

/// <summary>
/// Represents a product create handler.
/// </summary>
public class CreateProductHandler(IRepositoryManager repository) : IRequestHandler<CreateProductCommand, ProductResponse>
{
    private readonly IRepositoryManager _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    /// <summary>
    /// Handles a command.
    /// </summary>
    /// <param name="command">Command for product create.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the product.
    /// </returns>
    /// <exception cref="ApplicationException">Thrown when a product cannot be created.</exception>
    public async Task<ProductResponse> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = CatalogMapper.GetMapper.Map<Product>(command)
            ?? throw new BadRequestException("There is an issue mapping while creating new product.");

        var createdProduct = await _repository.Product.CreateAsync(product);
        var productResponse = CatalogMapper.GetMapper.Map<ProductResponse>(createdProduct);

        return productResponse;
    }
}