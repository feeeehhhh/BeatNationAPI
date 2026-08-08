using src.features.Beats.Command.Request;
using src.features.Beats.Command.Response;
using src.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace src.features.Beats.Handlers
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
                .ToListAsync(cancellationToken);

            return beats
                .Select(p => (BeatCreateResponse)p)
                .ToList();
        }
        

    }
}