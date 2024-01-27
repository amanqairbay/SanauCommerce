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

    public async Task<Catalog> GetPagedCatalog(int page, int take)
    {
        var queryStringParam = new Dictionary<string, string>
        {
            ["pageIndex"] = page.ToString(),
            ["pageSize"] = take.ToString()
        };

        var response = await _client.GetAsync(QueryHelpers.AddQueryString("products/paged", queryStringParam));
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new ApplicationException($"Something went wrong calling the API: {content}");
        }

        var catalog = JsonSerializer.Deserialize<Catalog>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return catalog;
        // return await response.ReadContentAs<Catalog>();
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
        //return await response.ReadContentAs<Product>();
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
}