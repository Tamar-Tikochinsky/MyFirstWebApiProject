using entities.Models;

namespace Repository
{
    public interface ICategoryRepository
    {
        Task<Category> addCategory(Category category);
        Task<Category> getCategoryById(int id);
        Task<IEnumerable<Category>> getCategories();
    }
}