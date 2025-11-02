using BeatNationAPI.Application.Licencas.Command.Request;
using BeatNationAPI.Common.Responses;
using BeatNationAPI.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BeatNationAPI.Application.Licencas.Handlers
{
    public class PresetUpdateHandler : IRequestHandler<PresetUpdateRequest, Response<Guid>>
    {
        private readonly AppDbContext _context;
        public PresetUpdateHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Response<Guid>> Handle(PresetUpdateRequest request, CancellationToken cancellationToken)
        {

            var preset = await _context.PresetLicencas
            .FirstOrDefaultAsync(p => p.Id == request.Id);

            if (preset == null)
            {
                return Response<Guid>.Fail("Não foi possível atulizar a liceça.");
            }

            preset.Nome = request.Nome;
            preset.Descricao = request.Descricao;

            await _context.SaveChangesAsync(cancellationToken);
            return Response<Guid>.Ok(preset.Id, "Licença atualizada com sucesso!");

        }
    }

}