using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Features.Products.Commands.UpdateProduct;

/// <summary>
/// Represents a command handler to update product.
/// </summary>
public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryManager _repository;

    public UpdateProductCommandHandler(IMapper mapper, IRepositoryManager repository)
    {
        _mapper  = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _repository  = repository ?? throw new ArgumentNullException(nameof(repository));
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
        var product = _mapper.Map<Product>(command) ?? throw new BadRequestException("There is an issue mapping while updating new product.");
        
        return await _repository.Product.UpdateAsync(product);
    }
}