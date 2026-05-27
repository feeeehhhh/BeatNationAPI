using BeatNationAPI.Application.Autentication.Command.Request;
using BeatNationAPI.Application.Autentication.Command.Response;
using BeatNationAPI.Data;
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

        public RegisterUserHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
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

            // Verifica se a senha existe e seta no usuário cadastrado
            var roleResult = await _userManager.AddToRoleAsync(user, "User");

            if (!roleResult.Succeeded)
            {
                var errors = string.Join(", ", roleResult.Errors.Select(e => e.Description));
                throw new InvalidOperationException(errors);
            }
            return (RegisterUserResponse)user;
        }


    }
}