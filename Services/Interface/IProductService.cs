using ProductManagement.API.DTOs.ProductDTOs;
using ProductManagement.API.Models;

namespace ProductManagement.API.Services.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetAsync(int id);
        Task<Product> CreateAsync(Product product);
        Task<bool> UpdateAsync(int id,Product product);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Product>> FilterAsync(ProductFilterDto productFilterDto);

    }
}
