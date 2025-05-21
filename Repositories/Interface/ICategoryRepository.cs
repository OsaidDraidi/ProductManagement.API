using ProductManagement.API.Models;

namespace ProductManagement.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>>GetAllAsync();
        Task<Category?> GetAsync(int id);
        Task<Category?> CreateAsync(Category category);
        Task<Category?> UpdateAsync(int id, Category category);
        Task<bool> DeleteAsync(int id);
        Task SaveChangesAsync();

        Task<bool> ExistsAsync(int id);
    }
}
