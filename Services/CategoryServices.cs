using entities.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryServices : ICategoryServices
    {
        ICategoryRepository _CategoryRepository;
        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _CategoryRepository = categoryRepository;
        }
        public async Task<Category> addCategory(Category category)
        {
            return await _CategoryRepository.addCategory(category);
        }

        public async Task<Category> getCategoryById(int id)
        {
            return await _CategoryRepository.getCategoryById(id);
        }

        public async Task<IEnumerable<Category>> getCategories()
        {
            return await _CategoryRepository.getCategories();
        }
    }
}
