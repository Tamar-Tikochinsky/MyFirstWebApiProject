using entities;
using entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductsServices: IProductsServices
    {
        IProductsRepository _ProductsRepository;
        public ProductsServices(IProductsRepository productsRepository)
        {
            _ProductsRepository = productsRepository;
        }

        public async Task<Product> addProduct(Product product)
        {
            return await _ProductsRepository.addProduct(product);
        }

        public async Task<Product> getProductById(int id)
        {
            return await _ProductsRepository.getProductById(id);
        }

        public async Task<IEnumerable<Product>> getProducts(string? desc, int? minPrice, int? maxPrice, [FromQuery] int?[] categoryIdys, int position = 1, int skip = 8)
        { 
            return await _ProductsRepository.getProducts(desc, minPrice, maxPrice, categoryIdys, position, skip);
        }


    }
}
