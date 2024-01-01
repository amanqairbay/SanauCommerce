using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

/// <summary>
/// Represents a catalog context seed.
/// </summary>
public class CatalogContextSeed
{
    public static void SeedData(
        IMongoCollection<Product> productCollection, 
        IMongoCollection<ProductBrand> productBrandsCollection,
        IMongoCollection<ProductType> productTypesCollection)
    {
        // add products
        bool existingProduct = productCollection.Find(p => true).Any();
        if (!existingProduct)
        {
            productCollection.InsertManyAsync(GetPreconfigurationProducts());
        }

        // add product brands
        bool existingProductBrand = productBrandsCollection.Find(pb => true).Any();
        if (!existingProductBrand)
        {
            productBrandsCollection.InsertManyAsync(GetPreconfigurationProductBrands());
        }

        // add product types
        bool existingProductType = productTypesCollection.Find(pt => true).Any();
        if (!existingProductType)
        {
            productTypesCollection.InsertManyAsync(GetPreconfigurationProductTypes());
        }
    }

    private static IEnumerable<ProductBrand> GetPreconfigurationProductBrands()
    {
        return new List<ProductBrand>()
        {
            new() { Id = "658d0b83a0611f637d3d967d", Name = "Google"},
            new() { Id = "658d0bc78426af4cf52f12f6", Name = "Samsung"},
            new() { Id = "658d0c0b01d4b9826c21fb87", Name = "Xiaomi"},
            new() { Id = "658d0c68a7003d045293dc8b", Name = "Apple"},
            new() { Id = "658d0c9047336208363af181", Name = "JBL"},
            new() { Id = "658d0cbb87e31ebe5ce03432", Name = "Sony"},
            new() { Id = "658d0cda23031a268eabb951", Name = "Dell"},
            new() { Id = "658d0d9fd5171dd40377ba24", Name = "Bose"}
        };
    }

    private static IEnumerable<ProductType> GetPreconfigurationProductTypes()
    {
        return new List<ProductType>()
        {
            new() { Id = "658d0e66d210722f633a9111", Name = "Smartphones"},
            new() { Id = "658d0e7d1df62ce8d5eda34f", Name = "VR Headsets"},
            new() { Id = "658d0e99d3c9907da9ba65ab", Name = "Laptops"},
            new() { Id = "658d0eb277372fcc25e8cdca", Name = "Headphones"},
            new() { Id = "658d0f2daa79f1fbfda6ecbb", Name = "Smartwatches"},
            new() { Id = "658d0f4ee6543d4fc5d8c7d2", Name = "Speakers"},
            new() { Id = "658d0f74003925fffa7535d8", Name = "Tablets"}
        };
    }
    
    private static IEnumerable<Product> GetPreconfigurationProducts()
    {
        return new List<Product>()
        {
            new Product()
            {
                Id = "602d2149e773f2a3990b47f5",
                Name = "Google Pixel 4a 128Gb Barely Blue",
                Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "product-pixel-4a.png",
                Brand = new ProductBrand { Id = "658d0b83a0611f637d3d967d", Name = "Google" },
                Type = new ProductType { Id = "658d0e66d210722f633a9111", Name = "Smartphones" },
                Price = 349
            },
            new Product()
            {
                Id = "657ad1c3566d0e35563eaa2c",
                Name = "Samsung Gear VR Headset",
                Summary = "This headset is the company's biggest change to its flagship headset in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "product-samsung-vr.png",
                Brand = new ProductBrand { Id = "658d0bc78426af4cf52f12f6", Name = "Samsung" },
                Type = new ProductType { Id = "658d0e7d1df62ce8d5eda34f", Name = "VR Headsets" },
                Price = 399
            },
            new Product()
            {
                Id = "602d2149e773f2a3990b47f6",
                Name = "Apple iPhone 11 128Gb Yellow",
                Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "product-iphone-yellow.png",
                Brand = new ProductBrand { Id = "658d0c68a7003d045293dc8b", Name = "Apple" },
                Type = new ProductType { Id = "658d0e66d210722f633a9111", Name = "Smartphones" },
                Price = 699
            },
            new Product()
            {
                Id = "602d2149e773f2a3990b47f7",
                Name = "Apple MacBook Pro 14 1Tb Silver",
                Summary = "This laptop is the company's biggest change to its flagship laptop in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "product-macbook-pro-14.png",
                Brand = new ProductBrand { Id = "658d0c68a7003d045293dc8b", Name = "Apple" },
                Type = new ProductType { Id = "658d0e99d3c9907da9ba65ab", Name = "Laptops" },
                Price = 2399
            },
            new Product()
            {
                Id = "602d2149e773f2a3990b47f8",
                Name = "JBL Tune TWS Blue",
                Summary = "This earphone is the company's biggest change to its flagship headphone in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "product-jbl-earphones.png",
                Brand = new ProductBrand { Id = "658d0c9047336208363af181", Name = "JBL" },
                Type = new ProductType { Id = "658d0eb277372fcc25e8cdca", Name = "Headphones" },
                Price = 89
            },
            new Product()
            {
                Id = "602d2149e773f2a3990b47f9",
                Name = "Apple Watch 7 Aluminum 45mm",
                Summary = "This watch is the company's biggest change to its flagship smartwatch in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "product-apple-watch.png",
                Brand = new ProductBrand { Id = "658d0c68a7003d045293dc8b", Name = "Apple" },
                Type = new ProductType { Id = "658d0f2daa79f1fbfda6ecbb", Name = "Smartwatches" },
                Price = 399
            },
            new Product()
            {
                Id = "602d2149e773f2a3990b47fa",
                Name = "Sony Smart Speaker",
                Summary = "This speaker is the company's biggest change to its flagship speaker in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "product-sony-speaker.png",
                Brand = new ProductBrand { Id = "658d0cbb87e31ebe5ce03432", Name = "Sony" },
                Type = new ProductType { Id = "658d0f4ee6543d4fc5d8c7d2", Name = "Speakers" },
                Price = 49
            },
            new Product()
            {
                Id = "657ad0de6a6adbe854952c7f",
                Name = "Xiaomi Redmi Note 10S 128Gb Pebble White",
                Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "product-redmi-note.png",
                Brand = new ProductBrand { Id = "658d0c0b01d4b9826c21fb87", Name = "Xiaomi" },
                Type = new ProductType { Id = "658d0e66d210722f633a9111", Name = "Smartphones" },
                Price = 349
            },
            new Product()
            {
                Id = "657ad1514d6a4e8ab3a72f11",
                Name = "Dell Latitude 5420 Ultrabook",
                Summary = "This laptop is the company's biggest change to its flagship laptop in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "product-dell-latitude.png",
                Brand = new ProductBrand { Id = "658d0cda23031a268eabb951", Name = "Dell" },
                Type = new ProductType { Id = "658d0e99d3c9907da9ba65ab", Name = "Laptops" },
                Price = 1299
            },
            new Product()
            {
                Id = "657ad6f91933a7c9b643a921",
                Name = "Samsung Galaxy Tab S6",
                Summary = "This tablet is the company's biggest change to its flagship tablet in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "product-samsung-tablet.png",
                Brand = new ProductBrand { Id = "658d0bc78426af4cf52f12f6", Name = "Samsung" },
                Type = new ProductType { Id = "658d0f74003925fffa7535d8", Name = "Tablets" },
                Price = 399
            },
            new Product()
            {
                Id = "657ad77149678fa2f87a1e0e",
                Name = "Bose QuietComphort 45",
                Summary = "This headphone is the company's biggest change to its flagship headphone in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "product-bose-headphones.png",
                Brand = new ProductBrand { Id = "658d0d9fd5171dd40377ba24", Name = "Bose" },
                Type = new ProductType { Id = "658d0eb277372fcc25e8cdca", Name = "Headphones" },
                Price = 299
            },
            new Product()
            {
                Id = "657ad7ca398839346546f69b",
                Name = "Xiaomi Redmi 10 128Gb Coral Blue",
                Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageFile = "product-xiaomi-redmi.png",
                Brand = new ProductBrand { Id = "658d0c0b01d4b9826c21fb87", Name = "Xiaomi" },
                Type = new ProductType { Id = "658d0e66d210722f633a9111", Name = "Smartphones" },
                Price = 199
            }
        };
    }        
}