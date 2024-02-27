using System.Text.Json;
using Microsoft.AspNetCore.WebUtilities;
using Web.MVC.Extensions;
using Web.MVC.ViewModels;

namespace Web.MVC.Services;

public class CatalogService : ICatalogService
{
    private readonly HttpClient _client;

    public CatalogService(HttpClient client)
    {
        _client = client ?? throw new ArgumentNullException(nameof(client));
    }

    public async Task<IEnumerable<Product>> GetCatalog()
    {
        var response = await _client.GetAsync("/Products");
        return await response.ReadContentAs<List<Product>>();
    }

    public async Task<Catalog> GetPagedCatalog(int page, int take, string typeId, List<string> brands)
    {
        var queryStringParam = new List<KeyValuePair<string, string>>();

        queryStringParam.Add(new KeyValuePair<string, string>("pageIndex", page.ToString()));
        queryStringParam.Add(new KeyValuePair<string, string>("pageSize", take.ToString()));
        
        if (typeId is not null)
        {
            queryStringParam.Add(new KeyValuePair<string, string>("typeId", typeId));
        }

        if (brands is not null)
        {
            foreach (var brand in brands)
            {
                queryStringParam.Add(new KeyValuePair<string, string>("brandId", brand));
            }
        }

        var response = await _client.GetAsync(QueryHelpers.AddQueryString("products/paged", queryStringParam));
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException($"Something went wrong calling the API: {content}");
        }

        var catalog = JsonSerializer.Deserialize<Catalog>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return catalog;
    }

    public async Task<Product> GetCatalog(string id)
    {
        var response = await _client.GetAsync($"/Products/{id}");
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException($"Something went wrong calling the API: {content}");
        }

        var product = JsonSerializer.Deserialize<Product>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return product;
    }

    public async Task<Product> GetCatalogByName(string name)
    {
        var response = await _client.GetAsync($"/Products/name/{name}");
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException($"Something went wrong calling the API: {content}");
        }

        var product = JsonSerializer.Deserialize<Product>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return product;
        //return await response.ReadContentAs<Product>();
    }

    public async Task<Product> GetCatalogBySeName(string seName)
    {
        var response = await _client.GetAsync($"/Products/seName/{seName}");
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException($"Something went wrong calling the API: {content}");
        }

        var product = JsonSerializer.Deserialize<Product>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return product;
    }

    public async Task<ProductImage> GetProductImageByName(string name)
    {
        var response = await _client.GetAsync($"/Photos/productPhoto/{name}");
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException($"Something went wrong calling the API: {content}");
        }

        var productImage = JsonSerializer.Deserialize<ProductImage>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return productImage;
    }

    public async Task<IEnumerable<Product>> GetCatalogByCategory(string category)
    {
        var response = await _client.GetAsync($"/Products/category/{category}");
        return await response.ReadContentAs<List<Product>>();
    }

    public async Task<Product> CreateCatalog(Product product)
    {
        var response = await _client.PostAsJson($"/Catalog", product);
        
        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<Product>();
        else
        {
            throw new Exception("Something went wrong when calling api.");
        }
    }

    public async Task<List<ProductType>> GetProductTypes()
    {
        var response = await _client.GetAsync($"/ProductTypes");
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException($"Something went wrong calling the API: {content}");
        }

        var productTypes = JsonSerializer.Deserialize<List<ProductType>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return productTypes;
    }

    public async Task<ProductType> GetProductType(string id)
    {
        var response = await _client.GetAsync($"/ProductTypes/{id}");
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException($"Something went wrong calling the API: {content}");
        }

        var productType = JsonSerializer.Deserialize<ProductType>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return productType;
    }

    public async Task<List<ProductBrand>> GetProductBrands()
    {
        var response = await _client.GetAsync($"/ProductBrands");
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException($"Something went wrong calling the API: {content}");
        }

        var productBrands = JsonSerializer.Deserialize<List<ProductBrand>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return productBrands;
    }

    public async Task<ProductBrand> GetProductBrand(string id)
    {
        var response = await _client.GetAsync($"/ProductBrands/{id}");
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException($"Something went wrong calling the API: {content}");
        }

        var productBrand = JsonSerializer.Deserialize<ProductBrand>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return productBrand;
    }
}