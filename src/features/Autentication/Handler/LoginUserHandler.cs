
using src.features.Autentication.Command.Request;
using src.features.Autentication.Command.Response;
using src.infra.data;
using src.features.Autentication.Handler;
using src.domain.models;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace src.features.Autentication.Handler
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, TokenResponseDto>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly TokenService _tokenService;
        private readonly AppDbContext _context;

        public LoginUserHandler(
            SignInManager<User> signInManager,
             UserManager<User> userManager,
              TokenService tokenService,
               AppDbContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
            _context = context;

        }

        public async Task<TokenResponseDto> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            // verificar se o usuário existe
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new InvalidOperationException("Usuário não encontrado");
            }
            else
            {
                // verificar se a senha está correta
                var result = await _signInManager.CheckPasswordSignInAsync(
                    user,
                    request.Password,
                    lockoutOnFailure: true // bloqueia o usuário após várias tentativas falhas de login
                     );
                var IsConfirmed = await _userManager.IsEmailConfirmedAsync(user);
                if (IsConfirmed == false)
                {
                    throw new InvalidOperationException("Confirmação de email pendente. Verifique seu email para ativar a conta.");
                }
                else if (result.IsLockedOut && user.LockoutEnd > DateTime.UtcNow)
                {
                    throw new InvalidOperationException("Usuário bloqueado devido a várias tentativas falhas de login. Tente novamente mais tarde.");
                } else if (result.IsLockedOut)
                {
                    throw new InvalidOperationException("Senha incorreta");
                }


                // Caso o login seja bem-sucedido, gerar o token JWT
                var accessToken = await _tokenService.GenerateToken(user);
                var refreshToken =  _tokenService.GenerateRefreshToken(user.Id);

                _context.RefreshTokens.Add(refreshToken);
                await _context.SaveChangesAsync();

                return new TokenResponseDto
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken.Token,
                    Expiration = DateTime.UtcNow.AddMinutes(15)
                };
            }
        }
    }
}