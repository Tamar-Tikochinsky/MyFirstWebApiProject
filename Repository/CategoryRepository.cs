using entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CookwareShopContext _CookwareShopContext;
        public CategoryRepository(CookwareShopContext cookwareShopContext)
        {
            _CookwareShopContext = cookwareShopContext;
        }
        public async Task<Category> addCategory(Category category)
        {
            await _CookwareShopContext.Categories.AddAsync(category);
            await _CookwareShopContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> getCategoryById(int id)
        {
            return await _CookwareShopContext.Categories.FindAsync(id);

        }

        public async Task<IEnumerable<Category>> getCategories()
        {
            return await _CookwareShopContext.Categories.ToListAsync();
        }
    }
}
