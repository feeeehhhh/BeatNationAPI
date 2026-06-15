using BeatNationAPI.Application.Autentication.Command.Request;
using BeatNationAPI.Interface;
using BeatNationAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;


namespace BeatNationAPI.Application.Autentication.Handler
{
    public class ForgotPasswordHandler : IRequestHandler<ForgotPasswordRequest>
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;
        public ForgotPasswordHandler(UserManager<User> userManager, IEmailService emailService)
        {
            _userManager = userManager;
            _emailService = emailService;
        }

        public async Task Handle(ForgotPasswordRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            Console.WriteLine($"Usuário encontrado: {user != null}");
            if (user == null ) // Verifica se o email está comfirmado || !(await _userManager.IsEmailConfirmedAsync(user))
            {
                return;
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = $"https://localhost:3000/reset-password?email={request.Email}&token={token}";

            
            await _emailService.SendAsync(
                request.Email,
                "Redefinir Senha",
                $"Clique aqui: {callbackUrl}"
            );
           
        }
    }
} 