
using Microsoft.IdentityModel.Tokens;
using ProductManagement.API.DTOs.AuthDtos;
using ProductManagement.API.Models;
using ProductManagement.API.Repositories.Interface;
using ProductManagement.API.Services.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductManagement.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<AuthenticationResponseDto> RegisterAsync(RegisterDto registerDto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                return new AuthenticationResponseDto
                {
                    IsAuthenticated = false,
                    ErrorMessage = "User already exists"
                };
            }

            if (registerDto.Password != registerDto.ConfirmPassword)
            {
                return new AuthenticationResponseDto
                {
                    IsAuthenticated = false,
                    ErrorMessage = "Password and confirmation password do not match"
                };
            }

            var newUser = new ApplicationUser
            {
                Email = registerDto.Email,
                UserName = registerDto.Email,
                FullName = registerDto.FullName,
            };

            var result = await _userRepository.CreateAsync(newUser, registerDto.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                return new AuthenticationResponseDto
                {
                    IsAuthenticated = false,
                    ErrorMessage = errors
                };
            }

            // 🟡 تعيين دور "User"
            var assignedRole = registerDto.Role ?? "User";
            await _userRepository.CreateRoleAsync(assignedRole);
            await _userRepository.AddToRoleAsync(newUser, assignedRole);

            // 🟡 إضافة Claim مثل "IsVerified"
            await _userRepository.AddClaimAsync(newUser, new Claim("IsVerified", "true"));
            // توليد توكن عند التسجيل مباشرة
            var token = await GenerateJwtToken(newUser);

            return new AuthenticationResponseDto
            {
                IsAuthenticated = true,
                Token = token
            };
        }

        public async Task<AuthenticationResponseDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetByEmailAsync(loginDto.Email);

            if (user == null)
            {
                return new AuthenticationResponseDto
                {
                    IsAuthenticated = false,
                    ErrorMessage = "User not found"
                };
            }

            var isPasswordValid = await _userRepository.CheckPasswordAsync(user, loginDto.Password);
            if (!isPasswordValid)
            {
                return new AuthenticationResponseDto
                {
                    IsAuthenticated = false,
                    ErrorMessage = "Invalid password"
                };
            }

            var token = await GenerateJwtToken(user);

            return new AuthenticationResponseDto
            {
                IsAuthenticated = true,
                Token = token
            };
        }

        private async Task<string> GenerateJwtToken(ApplicationUser user)
        {
            var jwtSettings = _configuration.GetSection("Jwt");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var userClaims = await _userRepository.GetUserClaimsAsync(user);
            var userRoles = await _userRepository.GetUserRolesAsync(user);

            // إضافة الادعاءات (claims) اللي في التوكن
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email ?? ""),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName ?? "")
            };

            // لو تريد تضيف أدوار مثلاً:
            // (هذا يحتاج استدعاء GetUserRolesAsync ثم تضيف كل دور كـ claim من نوع ClaimTypes.Role)

            // 🔵 إضافة Claims
            claims.AddRange(userClaims);

            // 🔵 إضافة Roles كـ Claim من نوع Role
            claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpiryInMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}