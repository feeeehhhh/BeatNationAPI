
using BeatNationAPI.Application.Command.Licencas.Response;
using BeatNationAPI.Application.Licencas.Command.Request;
using BeatNationAPI.Common.Responses;
using BeatNationAPI.Data;
using BeatNationAPI.Models;
using MediatR;


namespace BeatNationAPI.Application.Handlers
{
    public class LicencaCreateHandler :
     IRequestHandler<LicencaCreateRequest, Response<LicencaCreateResponse>>
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LicencaCreateHandler(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response<LicencaCreateResponse>> Handle(LicencaCreateRequest request, CancellationToken cancellationToken)
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
             //trocar quando implementar requisições via token

            if (licencas == null)
            {
                return Response<LicencaCreateResponse>.Fail("Não foi possível criar a licença, tente mais tarde");
            }

            // Salva no banco
            _context.Licencas.Add(licencas);
            await _context.SaveChangesAsync(cancellationToken);

    

            return Response<LicencaCreateResponse>.Ok(licencas, "Licença criado com sucesso !");

        }
    }


}