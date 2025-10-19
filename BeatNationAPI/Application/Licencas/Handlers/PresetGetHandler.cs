using BeatNationAPI.Application.Command.Licencas.Request;
using BeatNationAPI.Application.Licencas.Command.Response;
using BeatNationAPI.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class PresetGetAllHandler : IRequestHandler<PresetGetAllRequest, List<PresetCreateResponse>>
{
    private readonly AppDbContext _context;

    public PresetGetAllHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<PresetCreateResponse>> Handle(PresetGetAllRequest request, CancellationToken cancellationToken)
    {
        var presets = await _context.PresetLicencas
            .Include(p => p.Licencas)
                .ThenInclude(l => l.LicencaConfig)
            .ToListAsync(cancellationToken);

        return presets
            .Select(p => (PresetCreateResponse)p)
            .ToList();
    }
}
