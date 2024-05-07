using entities.Models;

namespace Services
{
    public interface ICategoryServices
    {
        Task<Category> addCategory(Category category);
        Task<Category> getCategoryById(int id);
        Task<IEnumerable<Category>> getCategories();
    }
}