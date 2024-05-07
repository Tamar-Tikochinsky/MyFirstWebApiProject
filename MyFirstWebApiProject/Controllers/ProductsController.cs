using AutoMapper;
using entities;
using entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Services;
using DTO;

namespace MyFirstWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        IProductsServices _ProductsServices;
        IMapper mapper;

        public ProductsController(IProductsServices productsServices, IMapper _mapper)
        {
            _ProductsServices = productsServices;
            mapper = _mapper;
        }
        // GET: ProductsController
        [HttpGet]
        public async Task<IEnumerable<ProductsDTO>> GetProducts(string? desc, int? minPrice, int? maxPrice,[FromQuery] int?[] categoryIdys, int position=1, int skip=8)
        {
            IEnumerable<Product> products = await _ProductsServices.getProducts(desc, minPrice, maxPrice, categoryIdys, position, skip);
            IEnumerable<ProductsDTO> productsDTOs = mapper.Map<IEnumerable<Product>,IEnumerable<ProductsDTO>>(products);
            return productsDTOs;
        }

        [HttpGet("{id}")]
        public async Task<ProductsDTO> getProductById(int id)
        {
            Product product = await _ProductsServices.getProductById(id);
            ProductsDTO productsDTO = mapper.Map<Product, ProductsDTO>(product);
            return productsDTO;
        }


        // POST api/<UsersController>
        [HttpPost]
        public async Task<ProductResPostDTO> Post([FromBody] ProductPostDTO productToAdd)
        {
            Product product = mapper.Map<ProductPostDTO, Product>(productToAdd);
            Product theAddProd = await _ProductsServices.addProduct(product);
            ProductResPostDTO productDTO = mapper.Map<Product, ProductResPostDTO>(theAddProd);
            return productDTO;
        }
    }
}
