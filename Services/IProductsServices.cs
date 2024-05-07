using entities;
using entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Services
{
    public interface IProductsServices
    {
        Task<Product> addProduct(Product product);
        Task<IEnumerable<Product>> getProducts(string? desc, int? minPrice, int? maxPrice, [FromQuery] int?[] categoryIdys, int position = 1, int skip = 8);

        Task<Product> getProductById(int id);
    }
}