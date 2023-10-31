using Catalog.Application.Commands;
using Catalog.Application.Mappers;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Queries;

/// <summary>
/// Represents a product create handler.
/// </summary>
public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResponse>
{
    private readonly IProductRepository _productRepository;

    public CreateProductHandler(IProductRepository productRepository) => _productRepository = productRepository;

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
            ?? throw new ApplicationException("There is an issue mapping while creating new product.");

        var newProduct = await _productRepository.CreateProductAsync(product);
        var productResponse = CatalogMapper.GetMapper.Map<ProductResponse>(newProduct);

        return productResponse;
    }
}