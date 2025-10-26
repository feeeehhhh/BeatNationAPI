using BeatNationAPI.Application.Command.Licencas.Response;
using BeatNationAPI.Application.Licencas.Command.Request;
using BeatNationAPI.Data;
using BeatNationAPI.Models;
using MediatR;


namespace BeatNationAPI.Application.Handlers
{
    public class LicencaCreateHandler :
     IRequestHandler<LicencaCreateRequest, LicencaCreateResponse>
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LicencaCreateHandler(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<LicencaCreateResponse> Handle(LicencaCreateRequest request, CancellationToken cancellationToken)
        {
            // Pega o id do IdUsuario via Token
            // var currentUserIdString = _httpContextAccessor.HttpContext.User
            // .FindFirst("id")?.Value; ;
            // // faz a conversão do string para Guid
            // if (!Guid.TryParse(currentUserIdString, out Guid currentUserId))
            // {
            //     throw new UnauthorizedAccessException("Token inválido ou ausente");
            // }

            Licenca licencas = request;
            licencas.Id = Guid.NewGuid();
            licencas.OwnerId = Guid.NewGuid(); //trocar quando implementar requisições via token

            // Salva no banco
            _context.Licencas.Add(licencas);
            await _context.SaveChangesAsync(cancellationToken);

            return licencas;

        }
    }


}