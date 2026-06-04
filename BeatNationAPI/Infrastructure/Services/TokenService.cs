
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BeatNationAPI.Application.Autentication.Command.Response;
using BeatNationAPI.Data;
using BeatNationAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace BeatNationAPI.Infrastructure.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public TokenService(IConfiguration configuration, AppDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _configuration = configuration;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }


        public async Task<string> GenerateToken(User user)
        {
            var now = DateTime.UtcNow;
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var PrivateKey = Environment.GetEnvironmentVariable("PRIVATE_KEY");
            var key = Encoding.ASCII.GetBytes(PrivateKey);
            var credential = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);

            var minduration = int.Parse(_configuration["Jwt:AcessTokenMinutes"] ?? "15");
            var expire = now.AddMinutes(minduration);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                notBefore: now,
                expires: expire,
                signingCredentials: credential);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public RefreshToken GenerateRefreshToken(Guid userId)
        {
            return new RefreshToken
            {
                UserId = userId,
                Token = GenerateRefreshToken(),
                ExpiresAt = DateTime.UtcNow.AddDays(
                    int.Parse(_configuration["Jwt:RefreshTokenDays"] ?? "7")
                ),
                Revoked = false
            };
        }
        private static string GenerateRefreshToken()
        {
            var randomBytes = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

        
    }
}