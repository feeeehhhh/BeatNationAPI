
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
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

        private static string GenerateRefreshTokenSecurity()
        {
            var randomBytes = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }
        public async Task<TokenResponseDto> GenerateToken(User user)
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

            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            var refreshToken = new RefreshToken
            {
                UserId = user.Id,
                Token = GenerateRefreshTokenSecurity(),
                ExpiresAt = now.AddDays(int.Parse(_configuration["Jwt:RefreshTokenDays"] ?? "7")),
                Revoked = false
            };
            _context.RefreshTokens.Add(refreshToken);
            await _context.SaveChangesAsync();


            _httpContextAccessor.HttpContext?.Response.Cookies.Append("accessToken", accessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = false,               // true se produção com HTTPS
                SameSite = SameSiteMode.Lax,
                Path = "/",
                Expires = expire
            });

            // Armazena o refresh token em um HttpOnly cookie
            _httpContextAccessor.HttpContext.Response.Cookies.Append("refreshToken", refreshToken.Token, new CookieOptions
            {
                HttpOnly = true,
                Secure = false, // HTTPS
                SameSite = SameSiteMode.Lax,
                Path = "/",
                Expires = refreshToken.ExpiresAt
            });

            return new TokenResponseDto
            {
                AccessToken = accessToken,
                Expiration = expire,
                RefreshToken = refreshToken.Token
            };
        }
        public async Task<TokenResponseDto?> RefreshTokens(string refreshToken)
        {
            var token = await _context.RefreshTokens
                .FirstOrDefaultAsync(r => r.Token == refreshToken && !r.Revoked);

            if (token == null || token.ExpiresAt <= DateTime.UtcNow)
                return null;

            var user = await _context.Users.FindAsync(token.UserId);
            if (user == null)
                return null;

            // revoga antigo
            token.Revoked = true;

            // cria novo refresh token
            var newRefreshToken = new RefreshToken
            {
                UserId = user.Id,
                Token = GenerateRefreshTokenSecurity(),
                ExpiresAt = DateTime.UtcNow.AddDays(
                    int.Parse(_configuration["Jwt:RefreshTokenDays"] ?? "7")
                ),
                Revoked = false
            };
            await _context.SaveChangesAsync();

            return await GenerateToken(user);
        }
    }
}