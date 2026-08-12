namespace src.application.Autentication.Handler
{
    using src.application.Autentication.Command.Request;
    using src.application.Autentication.Command.Response;
    using src.infra.data;
    using src.application.Autentication.Handler;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
  

    public sealed class RefreshTokenHandler : IRequestHandler<RefreshTokenRequest, TokenResponseDto>
    {
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;
        private readonly IConfiguration _configuration;

        public RefreshTokenHandler(AppDbContext context, TokenService tokenService, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<TokenResponseDto> Handle(
        RefreshTokenRequest request,
        CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.RefreshToken))
                throw new UnauthorizedAccessException();

            var token = await _context.RefreshTokens
                .FirstOrDefaultAsync(x => x.Token == request.RefreshToken && !x.Revoked);

            if (token == null || token.ExpiresAt <= DateTime.UtcNow)
                throw new UnauthorizedAccessException();

            var user = await _context.Users.FindAsync(token.UserId);

            if (user == null)
                throw new UnauthorizedAccessException();

            // revoga antigo
            token.Revoked = true;

            // cria novo refresh token
            var newRefreshToken = _tokenService.GenerateRefreshToken(user.Id);
            _context.RefreshTokens.Add(newRefreshToken);

            // cria access token
            var accessToken = await _tokenService.GenerateToken(user);

            await _context.SaveChangesAsync(cancellationToken);

            return new TokenResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = newRefreshToken.Token,
                Expiration = DateTime.UtcNow.AddMinutes(
                    int.Parse(_configuration["Jwt:AcessTokenMinutes"] ?? "15")
                )
            };

        }
    }
}
