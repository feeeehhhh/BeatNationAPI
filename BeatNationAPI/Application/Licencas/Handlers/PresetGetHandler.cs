using BeatNationAPI.Application.Command.Licencas.Request;
using BeatNationAPI.Application.Licencas.Command.Response;
using BeatNationAPI.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class PresetGetAllHandler : IRequestHandler<PresetGetAllRequest, List<PresetCreateResponse>>
{
    private readonly AppDbContext _context;
    private readonly HttpContextAccessor _httpContextAccessor;
    public PresetGetAllHandler(AppDbContext context, HttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<List<PresetCreateResponse>> Handle(PresetGetAllRequest request, CancellationToken cancellationToken)
    {
        // Pega o id do IdUsuario via Token
        var currentUserIdString = _httpContextAccessor.HttpContext.User
        .FindFirst("id")?.Value; ;
        // faz a conversão do string para Guid
        if (!Guid.TryParse(currentUserIdString, out Guid currentUserId))
        {
            throw new UnauthorizedAccessException("Token inválido ou ausente");
        }

        var presets = await _context.PresetLicencas
            .Where(p => p.OwnerId == currentUserId)
            .Include(p => p.Licencas)
                .ThenInclude(l => l.LicencaConfig)
            .ToListAsync(cancellationToken);

        return presets
            .Select(p => (PresetCreateResponse)p)
            .ToList();
    }
}
