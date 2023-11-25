using Catalog.Application.Commands;
using Catalog.Application.Mappers;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    /// <summary>
    /// Handles a command.
    /// </summary>
    /// <param name="command">Command for product update.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the update result.
    /// </returns>
    public async Task<bool> Handle(UpdateProductCommand command, CancellationToken cancellationToken) 
    {
        var product = CatalogMapper.GetMapper.Map<Product>(command)
            ?? throw new ApplicationException("There is an issue mapping while updating new product.");
        
        return await _productRepository.UpdateProductAsync(product);
    }
}