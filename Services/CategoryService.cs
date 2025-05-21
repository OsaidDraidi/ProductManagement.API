using ProductManagement.API.Models;
using ProductManagement.API.Repositories.Interface;
using ProductManagement.API.Services.Interface;

namespace ProductManagement.API.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _repo;
        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            if (category == null) { return null; }
            var created = await _repo.CreateAsync(category);

            if (created == null) { return null; }
            await _repo.SaveChangesAsync();
            return created;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleted = await _repo.DeleteAsync(id);

            return deleted;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var categories = await _repo.GetAllAsync();
            return categories;
        }

        public async Task<Category?> GetAsync(int id)
        {
            var product = await _repo.GetAsync(id);

            return product;
        }

        public async Task<bool> UpdateAsync(int id, Category category)
        {

            var updated = await _repo.UpdateAsync(id, category);
            if (updated == null) return false;
            return true;
        }
    }
}
