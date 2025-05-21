using ProductManagement.API.DTOs.ProductDTOs;
using ProductManagement.API.Models;

namespace ProductManagement.API.Repositories.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetAsync(int id);
        Task<Product?> CreateAsync(Product product);
        Task<Product?> UpdateAsync(int id,Product product);
        Task<bool> DeleteAsync(int id);
        Task SaveChangesAsync();
        Task<IEnumerable<Product>> FilterAsync(ProductFilterDto productFilterDto);

    }
}
