
using BeatNationAPI.Application.Licencas.Command.Request;
using BeatNationAPI.Common.Responses;
using BeatNationAPI.Data;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BeatNationAPI.Application.Licencas.Handlers
{
    public class LicencaDeleteHandler : IRequestHandler<LicencaDeleteRequest, Response<Guid>>
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LicencaDeleteHandler(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Response<Guid>> Handle(LicencaDeleteRequest request, CancellationToken cancellationToken)
        {
            // // Pega o id do IdUsuario via Token
            // var currentUserIdString = _httpContextAccessor.HttpContext.User
            // .FindFirst("id")?.Value; ;
            // // faz a conversão do string para Guid
            // if (!Guid.TryParse(currentUserIdString, out Guid currentUserId))
            // {
            //     throw new UnauthorizedAccessException("Token inválido ou ausente");
            // }

            var licenca = await _context.Licencas
            .FirstOrDefaultAsync(l => l.Id == request.Id /*&& l.OwnerId == currentUserId*/);
            if (licenca == null)
            {
                return Response<Guid>.Fail("Não foi possível excluir seua licença, tente mais tarde.");
            }

            _context.Licencas.Remove(licenca);
            await _context.SaveChangesAsync(cancellationToken);

            return Response<Guid>.Ok(licenca.Id, "Licença excluídas com sucesso !");
        }

    }
}