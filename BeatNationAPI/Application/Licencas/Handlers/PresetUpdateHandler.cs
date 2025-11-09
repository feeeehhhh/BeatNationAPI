using BeatNationAPI.Application.Licencas.Command.Request;
using BeatNationAPI.Common.Responses;
using BeatNationAPI.Data;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BeatNationAPI.Application.Licencas.Handlers
{
    public class PresetUpdateHandler : IRequestHandler<PresetUpdateRequest, Response<Guid>>
    {
        private readonly AppDbContext _context;
        private readonly IValidator<PresetUpdateRequest> _validator;
        public PresetUpdateHandler(AppDbContext context, IValidator<PresetUpdateRequest> validator)
        {
            _context = context;
            _validator = validator;
        }

        public async Task<Response<Guid>> Handle(PresetUpdateRequest request, CancellationToken cancellationToken)
        {
            // Valida o request

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return Response<Guid>.Fail("Falha na validação: " + string.Join(", ", errors));
            }
            
            var preset = await _context.PresetLicencas
            .FirstOrDefaultAsync(p => p.Id == request.Id);

            if (preset == null)
            {
                return Response<Guid>.Fail("Não foi possível atulizar a liceça.");
            }

            preset.Nome = request.Nome;
            preset.Descricao = request.Descricao;

            await _context.SaveChangesAsync(cancellationToken);
            return Response<Guid>.Ok(preset.Id, "Preset atualizado com sucesso!");

        }
    }

}