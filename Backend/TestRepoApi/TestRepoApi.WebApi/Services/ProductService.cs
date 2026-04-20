using TestRepoApi.WebApi.Models;
using TestRepoApi.WebApi.Services.Implementations;

namespace TestRepoApi.WebApi.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> products =
        [
            new() { Id = 1, Name = "Product1", Decription = "Decs P1", Price = 3.20m },
            new() { Id = 2, Name = "Product2", Decription = "Decs P2", Price = 4.20m },
            new() { Id = 3, Name = "Product3", Decription = "Decs P3", Price = 4.50m }
        ];

        public async Task<bool> CreateProductAsync(Product product)
        {
            var lastId = products.Count;

            if (product is not null)
            {
                product.Id = lastId++;
                products.Add(product);
                return await Task.FromResult(true); 
            }

            return await Task.FromResult(false);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = products.Find(p => p.Id == id);

            if (product is not null)
            {
                products.Remove(product);
                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }

        public async Task<List<Product>> GetAllProductsAsync() => 
            await Task.FromResult(products);

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            var product = products.Find(p => p.Id == id);

            if (product is not null)
            {
                return await Task.FromResult(product);
            }

            return await Task.FromResult(new Product());
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            if (product is not null)
            {
                var updatedProduct = products.Find(p => p.Id == product.Id);

                updatedProduct!.Name = product.Name;
                updatedProduct.Decription = product.Decription;
                updatedProduct.Price = product.Price;

                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }
    }
}
