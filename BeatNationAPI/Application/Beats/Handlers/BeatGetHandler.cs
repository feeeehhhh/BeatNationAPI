using BeatNationAPI.Application.Beats.Command.Request;
using BeatNationAPI.Application.Beats.Command.Response;
using BeatNationAPI.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BeatNationAPI.Application.Beats.Handlers
{
    public class BeatGetHandler : IRequestHandler<BeatGetRequest, List<BeatCreateResponse>>
    {
        private readonly AppDbContext _context;
        public BeatGetHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<BeatCreateResponse>> Handle(BeatGetRequest request, CancellationToken cancellationToken)
        {
            var beats = await _context.Beats
                .Include(p => p.Colaboradores)
                .Include(p => p.BeatLicencas)
                .ToListAsync(cancellationToken);

            return beats
                .Select(p => (BeatCreateResponse)p)
                .ToList();
        }


    }
}