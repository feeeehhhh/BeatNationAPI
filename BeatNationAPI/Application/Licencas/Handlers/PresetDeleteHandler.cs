using BeatNationAPI.Data;
using MediatR;

namespace BeatNationAPI.Application.Licencas.Command.Request
{
    public class PreseteDeleteHanler : IRequestHandler<PresetDeleteRequest>
    {
        private readonly AppDbContext _context;
        public PreseteDeleteHanler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(PresetDeleteRequest request, CancellationToken cancellationToken)
        {
            var preset = await _context.PresetLicencas.FindAsync(request.Id);
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