using AutoMapper;
using DTO;
using entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryServices _CategoryServices;
        IMapper mapper;
        public CategoryController(ICategoryServices categoryServices, IMapper _mapper)
        {
            _CategoryServices = categoryServices;
            mapper = _mapper;
        }
        // GET: api/<Category>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategorysDTO>>> GetCategories()
        {
            IEnumerable<Category> categories = await _CategoryServices.getCategories();
            IEnumerable<CategorysDTO> categorysDTOs = mapper.Map<IEnumerable<Category>, IEnumerable<CategorysDTO>>(categories);
            return Ok(categorysDTOs);
            
        }

        // GET api/<Category>/5
        [HttpGet("{id}")]
        public async Task<CategorysDTO> getCategoryById(int id)
        {
            Category category= await _CategoryServices.getCategoryById(id);
            CategorysDTO categoryDTO = mapper.Map<Category,CategorysDTO>(category);
            return categoryDTO;
        }

        // POST api/<Category>
        [HttpPost]
        public async Task<CategorysDTO> Post([FromBody] CategoryPostDTO category)
        {
            Category toAddCategory = mapper.Map<CategoryPostDTO, Category>(category);
            Category theAddCategory = await _CategoryServices.addCategory(toAddCategory);
            CategorysDTO finalCategory = mapper.Map<Category, CategorysDTO>(theAddCategory);

            return finalCategory;
        }

    }
}
