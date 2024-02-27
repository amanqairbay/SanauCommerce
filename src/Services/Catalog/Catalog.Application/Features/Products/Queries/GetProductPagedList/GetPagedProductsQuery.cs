using Catalog.Application.Responses;
using Catalog.Core.RequestFeatures;
using MediatR;

namespace Catalog.Application.Features.Products.Queries.GetProductPagedList;

public class GetPagedProductsQuery : IRequest<Pagination<ProductResponse>> 
{
    /// <summary>
    /// Gets or sets a product parameters.
    /// </summary>
    public ProductParameters ProductParams { get; set; }

    public GetPagedProductsQuery(ProductParameters productParams)
    {
        ProductParams = productParams;
    }
}