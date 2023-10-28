using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using Catalog.Core.RequestFeatures;
using MediatR;

namespace Catalog.Application.Handlers;

public class GetPagedProductsHandler : IRequestHandler<GetPagedProductsQuery, Pagination<ProductResponse>>
{
    private readonly IProductRepository _productRepository;

    public GetPagedProductsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<Pagination<ProductResponse>> Handle(GetPagedProductsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}