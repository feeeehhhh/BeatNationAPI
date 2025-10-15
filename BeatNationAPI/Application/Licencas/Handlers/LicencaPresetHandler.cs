
using System.Runtime.InteropServices;
using BeatNationAPI.Application.Command.Licencas.Request;
using BeatNationAPI.Application.Licencas.Command.Response;
using BeatNationAPI.Data;
using BeatNationAPI.Models;
using MediatR;

namespace BeatNationAPI.Application.Licencas.Command
{

    public class PresetCreateHandler :
        IRequestHandler<PresetCreateRequest, PresetCreateResponse>
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PresetCreateHandler(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;



        }

        public async Task<PresetCreateResponse> Handle(PresetCreateRequest request, CancellationToken cancellationToken)
        {
            // Pega o id do IdUsuario via Token
            var currentUserIdString = _httpContextAccessor.HttpContext.User
            .FindFirst("id")?.Value; ;
            // faz a conversão do string para Guid
            if (!Guid.TryParse(currentUserIdString, out Guid currentUserId))
            {
                throw new UnauthorizedAccessException("Token inválido ou ausente");
            }

            PresetLicenca presetLicenca = request;
            presetLicenca.Id = Guid.NewGuid();
            presetLicenca.OwnerId = currentUserId;
            presetLicenca.Licencas = new List<PresetLicencaConfig>();
            
            

            // Salva no banco
            _context.PresetLicencas.Add(presetLicenca);
            await _context.SaveChangesAsync(cancellationToken);

            return presetLicenca;
        }

    }


}
