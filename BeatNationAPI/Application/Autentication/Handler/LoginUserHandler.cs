
using BeatNationAPI.Application.Autentication.Command.Request;
using BeatNationAPI.Application.Autentication.Command.Response;
using BeatNationAPI.Infrastructure.Services;
using BeatNationAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace BeatNationAPI.Application.Autentication.Handler
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, TokenResponseDto>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly TokenService _tokenService;

        public LoginUserHandler(SignInManager<User> signInManager, UserManager<User> userManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<TokenResponseDto> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            // verificar se o usuário existe
           var user =  await _userManager.FindByEmailAsync(request.Email);
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
                    lockoutOnFailure:true // bloqueia o usuário após várias tentativas falhas de login
                     );
                if (!result.Succeeded){
                    throw new InvalidOperationException("Senha incorreta");
                }
                // Caso o login seja bem-sucedido, gerar o token JWT
                var tokenResponse = await _tokenService.GenerateToken(user);

                return tokenResponse;
                
            }

           
        }


    }
}