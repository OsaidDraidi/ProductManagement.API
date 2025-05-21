using ProductManagement.API.DTOs.ProductDTOs;
using ProductManagement.API.Models;
using ProductManagement.API.Repositories.Interface;
using ProductManagement.API.Services.Interface;

namespace ProductManagement.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly ICategoryRepository _categoryRepository;
        public ProductService(IProductRepository repo, ICategoryRepository categoryRepository)
        {
            _repo = repo;
            _categoryRepository = categoryRepository;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            
            if (product == null) { return null; }
            var categoryExists=await _categoryRepository.ExistsAsync(product.CategoryId);
           
            if (!categoryExists) {
                throw new("the Category is not Exist");
            }
            var created = await _repo.CreateAsync(product);

           
            await _repo.SaveChangesAsync();
            return created;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleted = await _repo.DeleteAsync(id);
            
            return deleted;
        }

        public async Task<IEnumerable<Product>> FilterAsync(ProductFilterDto productFilterDto)
        {
            return await _repo.FilterAsync(productFilterDto);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await _repo.GetAllAsync();
            return products;
        }

        public async Task<Product?> GetAsync(int id)
        {
            var product = await _repo.GetAsync(id);

            return product;
        }

        public async Task<bool> UpdateAsync(int id, Product product)
        {
            var updated = await _repo.UpdateAsync(id, product);
            if (updated == null) return false;
            return true;
        }
    }
}
