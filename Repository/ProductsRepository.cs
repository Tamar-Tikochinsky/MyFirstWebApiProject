using entities;
using entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly CookwareShopContext _CookwareShopContext;
        public ProductsRepository(CookwareShopContext cookwareShopContext)
        {
            _CookwareShopContext = cookwareShopContext;
        }
        public async Task<Product> addProduct(Product product)
        {
            await _CookwareShopContext.Products.AddAsync(product);
            await _CookwareShopContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> getProductById(int id)
        {
            return await _CookwareShopContext.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.ProductId == id);
        }
        public async Task<decimal> checkSumOrder(List<int> productIDs)
        {
            decimal sum = 0;
            for (var i = 0; i < productIDs.Count(); i++)
            {
                Product prod = await _CookwareShopContext.Products.FindAsync(productIDs[i]);
                sum += (decimal)prod.Price;
            }
            return sum;
        }
        public async Task<IEnumerable<Product>> getProducts(string? desc, int? minPrice, int? maxPrice, [FromQuery] int?[] categoryIdys, int position = 1, int skip = 8)
        {
            var query = _CookwareShopContext.Products.Include(product => product.Category)
                .Where(product =>
                (desc == null ? (true) : (product.Description.Contains(desc)))
                && ((minPrice == null) ? (true) : (product.Price >= minPrice))
                && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
                && ((categoryIdys.Length == 0) ? (true) : (categoryIdys.Contains(product.CategoryId))))
                .OrderBy(product => product.Price);
            Console.WriteLine(query.ToQueryString());
            List<Product> products = await query.ToListAsync();
            return products;

        }
    }
}
