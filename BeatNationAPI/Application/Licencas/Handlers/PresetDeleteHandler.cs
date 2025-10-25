using BeatNationAPI.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BeatNationAPI.Application.Licencas.Command.Request
{
    public class PreseteDeleteHanler : IRequestHandler<PresetDeleteRequest>
    {
        private readonly AppDbContext _context;
        private readonly HttpContextAccessor _httpContextAccessor;
        public PreseteDeleteHanler(AppDbContext context, HttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Guid> Handle(PresetDeleteRequest request, CancellationToken cancellationToken)
        {
            // Pega o id do IdUsuario via Token
            var currentUserIdString = _httpContextAccessor.HttpContext.User
            .FindFirst("id")?.Value; ;
            // faz a conversão do string para Guid
            if (!Guid.TryParse(currentUserIdString, out Guid currentUserId))
            {
                throw new UnauthorizedAccessException("Token inválido ou ausente");
            }

            var preset = await _context.PresetLicencas
            .FirstOrDefaultAsync(p => p.Id == request.Id && p.OwnerId == currentUserId);
            
            if (preset == null)
            {
                throw new Exception("Não foi possível deletar o preset");
            }

            _context.PresetLicencas.Remove(preset);
            await _context.SaveChangesAsync(cancellationToken);

            return preset.Id;
        }

        Task IRequestHandler<PresetDeleteRequest>.Handle(PresetDeleteRequest request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
}