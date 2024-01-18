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
        IMongoCollection<ProductType> productTypesCollection,
        IMongoCollection<ProductImage> productImageCollection)
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

        // add product images
        bool existingProductImage = productImageCollection.Find(pi => true).Any();
        if (!existingProductImage)
        {
            productImageCollection.InsertManyAsync(GetPreconfigurationImages());
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

    private static IEnumerable<ProductImage> GetPreconfigurationImages()
    {
        return new List<ProductImage>()
        {
            new() { Id = "65a0dd2741113178543d839b", IsMain = true, Name = "product-pixel-4a.png" }, // 1
            new() { Id = "65a0dd5368dc554a4d2c0214", IsMain = true, Name = "product-samsung-vr.png" }, // 2
            new() { Id = "65a0ddcc6d6340372dd0c657", IsMain = true, Name = "product-iphone-yellow.png" }, // 3
            new() { Id = "65a0de35ed427d4f905feebd", IsMain = true, Name = "product-macbook-pro-14.png" }, // 4
            new() { Id = "65a0de611b7a6d40a8150e69", IsMain = true, Name = "product-jbl-earphones.png" }, // 5
            new() { Id = "65a0dedef0fe39d079bc2573", IsMain = true, Name = "product-apple-watch.png" }, // 6
            new() { Id = "65a0df3e3f16e6edc732d20e", IsMain = true, Name = "product-sony-speaker.png" }, // 7
            new() { Id = "65a0e0094d3a0a0f649ddbf6", IsMain = true, Name = "product-redmi-note.png" }, // 8
            new() { Id = "65a0e0864d6b8dda9ac403d7", IsMain = true, Name = "product-dell-latitude.png" }, // 9
            new() { Id = "65a0e0d2f578d4796459024d", IsMain = true, Name = "product-samsung-tablet.png" }, // 10
            new() { Id = "65a0e10f026e60cb1f22e829", IsMain = true, Name = "product-bose-headphones.png" }, // 11
            new() { Id = "65a0e11be563fc013ed8e3ba", IsMain = true, Name = "product-xiaomi-redmi.png" } // 12
        };
    }
    
    private static IEnumerable<Product> GetPreconfigurationProducts()
    {
        return new List<Product>()
        {
            new() // 1
            {
                Id = "602d2149e773f2a3990b47f5",
                Name = "Google Pixel 4a 128Gb Barely Blue",
                Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageIds = ["65a0dd2741113178543d839b"],
                BrandId = "658d0b83a0611f637d3d967d",
                TypeId = "658d0e66d210722f633a9111",
                Price = 349
            },
            new() // 2
            {
                Id = "657ad1c3566d0e35563eaa2c",
                Name = "Samsung Gear VR Headset",
                Summary = "This headset is the company's biggest change to its flagship headset in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageIds = ["65a0dd5368dc554a4d2c0214"],
                BrandId = "658d0bc78426af4cf52f12f6",
                TypeId = "658d0e7d1df62ce8d5eda34f",
                Price = 399
            },
            new() // 3
            {
                Id = "602d2149e773f2a3990b47f6",
                Name = "Apple iPhone 11 128Gb Yellow",
                Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageIds = ["65a0ddcc6d6340372dd0c657"],
                BrandId = "658d0c68a7003d045293dc8b",
                TypeId = "658d0e66d210722f633a9111",
                Price = 699
            },
            new() // 4
            {
                Id = "602d2149e773f2a3990b47f7",
                Name = "Apple MacBook Pro 14 1Tb Silver",
                Summary = "This laptop is the company's biggest change to its flagship laptop in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageIds = ["65a0de35ed427d4f905feebd"],
                BrandId = "658d0c68a7003d045293dc8b",
                TypeId = "658d0e99d3c9907da9ba65ab",
                Price = 2399
            },
            new() // 5
            {
                Id = "602d2149e773f2a3990b47f8",
                Name = "JBL Tune TWS Blue",
                Summary = "This earphone is the company's biggest change to its flagship headphone in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageIds = ["65a0de611b7a6d40a8150e69"],
                BrandId = "658d0c9047336208363af181",
                TypeId = "658d0eb277372fcc25e8cdca",
                Price = 89
            },
            new() // 6
            {
                Id = "602d2149e773f2a3990b47f9",
                Name = "Apple Watch 7 Aluminum 45mm",
                Summary = "This watch is the company's biggest change to its flagship smartwatch in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageIds = ["65a0dedef0fe39d079bc2573"],
                BrandId = "658d0c68a7003d045293dc8b",
                TypeId = "658d0f2daa79f1fbfda6ecbb",
                Price = 399
            },
            new() // 7
            {
                Id = "602d2149e773f2a3990b47fa",
                Name = "Sony Smart Speaker",
                Summary = "This speaker is the company's biggest change to its flagship speaker in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageIds = ["65a0df3e3f16e6edc732d20e"],
                BrandId = "658d0cbb87e31ebe5ce03432",
                TypeId = "658d0f4ee6543d4fc5d8c7d2",
                Price = 49
            },
            new() // 8
            {
                Id = "657ad0de6a6adbe854952c7f",
                Name = "Xiaomi Redmi Note 10S 128Gb Pebble White",
                Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageIds = ["65a0e0094d3a0a0f649ddbf6"],
                BrandId = "658d0c0b01d4b9826c21fb87",
                TypeId = "658d0e66d210722f633a9111",
                Price = 349
            },
            new() // 9
            {
                Id = "657ad1514d6a4e8ab3a72f11",
                Name = "Dell Latitude 5420 Ultrabook",
                Summary = "This laptop is the company's biggest change to its flagship laptop in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageIds = ["65a0e0864d6b8dda9ac403d7"],
                BrandId = "658d0cda23031a268eabb951",
                TypeId = "658d0e99d3c9907da9ba65ab",
                Price = 1299
            },
            new() // 10
            {
                Id = "657ad6f91933a7c9b643a921",
                Name = "Samsung Galaxy Tab S6",
                Summary = "This tablet is the company's biggest change to its flagship tablet in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageIds = ["65a0e0d2f578d4796459024d"],
                BrandId = "658d0bc78426af4cf52f12f6",
                TypeId = "658d0f74003925fffa7535d8",
                Price = 399
            },
            new() // 11
            {
                Id = "657ad77149678fa2f87a1e0e",
                Name = "Bose QuietComphort 45",
                Summary = "This headphone is the company's biggest change to its flagship headphone in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageIds = ["65a0e10f026e60cb1f22e829"],
                BrandId = "658d0d9fd5171dd40377ba24",
                TypeId = "658d0eb277372fcc25e8cdca",
                Price = 299
            },
            new() // 12
            {
                Id = "657ad7ca398839346546f69b",
                Name = "Xiaomi Redmi 10 128Gb Coral Blue",
                Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                ImageIds = ["65a0e11be563fc013ed8e3ba"],
                BrandId = "658d0c0b01d4b9826c21fb87",
                TypeId = "658d0e66d210722f633a9111",
                Price = 199
            }
        };
    }        
}