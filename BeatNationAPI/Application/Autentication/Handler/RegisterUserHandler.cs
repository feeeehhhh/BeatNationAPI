using BeatNationAPI.Application.Autentication.Command.Request;
using BeatNationAPI.Application.Autentication.Command.Response;
using BeatNationAPI.Data;
using BeatNationAPI.Interface;
using BeatNationAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace BeatNationAPI.Application.Autentication.Handler
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserRequest, RegisterUserResponse>
    {

        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;

        public RegisterUserHandler(UserManager<User> userManager, IEmailService emailService)
        {
            _userManager = userManager;
            _emailService = emailService;
        }

        public async Task<RegisterUserResponse> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {

            var user = new User
            { 

                UserName = request.UserName,
                Name = request.Name,
                Email = request.Email,

            };
            // Cria o usuario no banco e sata a passwordHash
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException("Falha ao criar o usuário: " + errors);
            }

            // Verifica se a regra existe e seta no usuário cadastrado
            var roleResult = await _userManager.AddToRoleAsync(user, "User");

            if (!roleResult.Succeeded)
            {
                var errors = string.Join(", ", roleResult.Errors.Select(e => e.Description));
                throw new InvalidOperationException(errors);
            }

            var tokenConfirmation = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = $"https://localhost:3000/confirm-email?email={request.Email}&token={tokenConfirmation}";

            await _emailService.SendAsync(
                request.Email,
                "Confirme seu email",
                $"Clique aqui: {callbackUrl}"
            );

            return (RegisterUserResponse)user;
        }


    }
}