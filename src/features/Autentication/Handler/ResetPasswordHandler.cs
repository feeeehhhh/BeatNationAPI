using src.features.Autentication.Command.Request;
using src.domain.models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace src.features.Autentication.Handler
{
    public class ResetPasswordHandler : IRequestHandler<ResetPasswordRequest>
    {
        private readonly UserManager<User> _userManager;
        public ResetPasswordHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            var result = await _userManager.ResetPasswordAsync
            (user,
             request.Token,
              request.NewPassword);
              
            if (!result.Succeeded)
            {
                throw new Exception("Erro ao redefinir senha");
            }
        }
    }
}


