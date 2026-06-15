using BeatNationAPI.Application.Autentication.Command.Request;
using BeatNationAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace BeatNationAPI.Application.Autentication.Handler
{
   public class ConfirmEmailHandler : IRequestHandler<ConfirmEmailRequest>
    {
        private readonly UserManager<User> _userManager;

        public ConfirmEmailHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task Handle(ConfirmEmailRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.email);
            if (user == null)
            {
                throw new InvalidOperationException("Usuário não encontrado.");
            }

            var result = await _userManager.ConfirmEmailAsync(user, request.Token);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Falha ao confirmar email: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }

        }
    }
}