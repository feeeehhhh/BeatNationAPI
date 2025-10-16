using BeatNationAPI.Application.Command.Licencas.Request;
using BeatNationAPI.Application.Licencas.Command.Response;
using BeatNationAPI.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class LicencaGetHandler : IRequestHandler<LicencaGetRequest, List<LicencaCreateResponse>>
{
    private readonly AppDbContext _context;

    public LicencaGetHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<LicencaCreateResponse>> Handle(LicencaGetRequest request, CancellationToken cancellationToken)
    {
        var licencas = await _context.Licencas
            .Include(p => p.LicencaConfig)
            .ToListAsync(cancellationToken);

        return licencas
            .Select(p => (LicencaCreateResponse)p)
            .ToList();
    }


}
