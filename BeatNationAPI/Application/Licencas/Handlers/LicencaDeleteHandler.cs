using BeatNationAPI.Application.Licencas.Command.Request;
using BeatNationAPI.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BeatNationAPI.Application.Licencas.Handlers
{
    public class LicencaDeleteHandler : IRequestHandler<LicencaDeleteRequest>
    {
        private readonly AppDbContext _context;
        private readonly HttpContextAccessor _httpContextAccessor;
        public LicencaDeleteHandler(AppDbContext context, HttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Guid> Handle(LicencaDeleteRequest request, CancellationToken cancellationToken)
        {
            // Pega o id do IdUsuario via Token
            var currentUserIdString = _httpContextAccessor.HttpContext.User
            .FindFirst("id")?.Value; ;
            // faz a conversão do string para Guid
            if (!Guid.TryParse(currentUserIdString, out Guid currentUserId))
            {
                throw new UnauthorizedAccessException("Token inválido ou ausente");
            }

            var licenca = await _context.Licencas
            .FirstOrDefaultAsync(l => l.Id == request.Id && l.OwnerId == currentUserId);
            if (licenca == null)
            {
                throw new Exception("Não foi possível deletar a licença");
            }

            _context.Licencas.Remove(licenca);
            await _context.SaveChangesAsync(cancellationToken);

            return licenca.Id;
        }

        Task IRequestHandler<LicencaDeleteRequest>.Handle(LicencaDeleteRequest request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
}