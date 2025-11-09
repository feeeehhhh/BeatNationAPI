
using BeatNationAPI.Application.Command.Licencas.Request;
using BeatNationAPI.Application.Licencas.Command.Response;
using BeatNationAPI.Common.Responses;
using BeatNationAPI.Data;
using BeatNationAPI.Models;
using FluentValidation;
using MediatR;

namespace BeatNationAPI.Application.Licencas.Command
{

    public class PresetCreateHandler :
        IRequestHandler<PresetCreateRequest, Response<PresetCreateResponse>>
    {
        private readonly AppDbContext _context;
        private readonly IValidator<PresetCreateRequest> _validator;
        public PresetCreateHandler(AppDbContext context, IValidator<PresetCreateRequest> validator)
        {
            _context = context;
            _validator = validator;
        }

        public async Task<Response<PresetCreateResponse>> Handle(PresetCreateRequest request, CancellationToken cancellationToken)
        {

            // Valida o request

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return Response<PresetCreateResponse>.Fail("Falha na validação" + errors);
            }

            PresetLicenca presetLicenca = request;
            presetLicenca.Id = Guid.NewGuid();
            presetLicenca.OwnerId = Guid.NewGuid();
            presetLicenca.Licencas = new List<Licenca>();

            if (presetLicenca == null)
            {
                return Response<PresetCreateResponse>.Fail("Não foi possível criar o preset, tente mais tarde.");
            }


            // Salva no banco
            _context.PresetLicencas.Add(presetLicenca);
            await _context.SaveChangesAsync(cancellationToken);

            return Response<PresetCreateResponse>.Ok(presetLicenca, "Preset criado com sucesso !");
        }

    }


}
