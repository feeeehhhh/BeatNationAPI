using BeatNationAPI.Application.Command.Licencas.Request;
using BeatNationAPI.Application.Command.Licencas.Response;
using BeatNationAPI.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class LicencaGetHandler : IRequestHandler<LicencaGetRequest, List<LicencaCreateResponse>>
{
    private readonly AppDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LicencaGetHandler(AppDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<List<LicencaCreateResponse>> Handle(LicencaGetRequest request, CancellationToken cancellationToken)
    {
        // // Pega o id do IdUsuario via Token
        // var currentUserIdString = _httpContextAccessor.HttpContext.User
        // .FindFirst("id")?.Value; ;
        // // faz a conversão do string para Guid
        // if (!Guid.TryParse(currentUserIdString, out Guid currentUserId))
        // {
        //     throw new UnauthorizedAccessException("Token inválido ou ausente");
        // }

        var licencas = await _context.Licencas
       // .Where(l => l.OwnerId == currentUserId)
            .ToListAsync(cancellationToken);

        return licencas
            .Select(p => (LicencaCreateResponse)p)
            .ToList();
    }


}
