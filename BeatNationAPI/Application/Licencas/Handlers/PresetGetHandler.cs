using BeatNationAPI.Application.Command.Licencas.Request;
using BeatNationAPI.Application.Licencas.Command.Response;
using BeatNationAPI.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class PresetGetAllHandler : IRequestHandler<PresetGetAllRequest, List<PresetCreateResponse>>
{
    private readonly AppDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public PresetGetAllHandler(AppDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<List<PresetCreateResponse>> Handle(PresetGetAllRequest request, CancellationToken cancellationToken)
    {

        var presets = await _context.PresetLicencas
        .Include(p =>p.Licencas )
          //  .Where(p => p.OwnerId == currentUserId)
            .ToListAsync(cancellationToken);

        return presets
            .Select(p => (PresetCreateResponse)p)
            .ToList();
    }
}
