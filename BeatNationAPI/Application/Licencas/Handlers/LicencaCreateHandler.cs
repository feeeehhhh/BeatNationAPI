using BeatNationAPI.Application.Command.Licencas.Response;
using BeatNationAPI.Data;
using BeatNationAPI.Models;
using MediatR;
using NPOI.SS.Formula.Functions;

namespace BeatNationAPI.Application.Handlers
{
    public class LicencaCreateHandler :
     IRequestHandler<LicencaCreateRequest, LicencaCreateResponse>
    {
        private readonly AppDbContext _context;
        private readonly HttpContextAccessor _httpContextAccessor;

        public LicencaCreateHandler(AppDbContext context, HttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<LicencaCreateResponse> Handle(LicencaCreateRequest request, CancellationToken cancellationToken)
        {
            // Pega o id do IdUsuario via Token
            var currentUserIdString = _httpContextAccessor.HttpContext.User
            .FindFirst("id")?.Value; ;
            // faz a conversão do string para Guid
            if (!Guid.TryParse(currentUserIdString, out Guid currentUserId))
            {
                throw new UnauthorizedAccessException("Token inválido ou ausente");
            }

            Licenca licencas = request;
            licencas.Id = Guid.NewGuid();
            licencas.OwnerId = currentUserId;

            // Salva no banco
            _context.Licencas.Add(licencas);
            await _context.SaveChangesAsync(cancellationToken);

            return licencas;

        }
    }


}