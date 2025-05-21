using Microsoft.AspNetCore.Identity;
using ProductManagement.API.Models;
using System.Security.Claims;

namespace ProductManagement.API.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<ApplicationUser?> GetByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);


        Task<bool> RoleExistsAsync(string roleName);
        Task CreateRoleAsync(string roleName);
        Task AddToRoleAsync(ApplicationUser user, string roleName);
        Task<IList<string>> GetUserRolesAsync(ApplicationUser user);


        Task AddClaimAsync(ApplicationUser user, Claim claim);
        Task<IList<Claim>> GetUserClaimsAsync(ApplicationUser user);
    }
}
