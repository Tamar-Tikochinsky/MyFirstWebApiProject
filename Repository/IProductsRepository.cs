using entities;
using entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Repository
{
    public interface IProductsRepository
    {

        Task<Product> addProduct(Product product);
        Task<IEnumerable<Product>> getProducts(string? desc, int? minPrice, int? maxPrice, [FromQuery] int?[] categoryIdys, int position = 1, int skip = 8);

        Task<Product> getProductById(int id);
        Task<decimal> checkSumOrder(List<int> productIDs);
    }
}