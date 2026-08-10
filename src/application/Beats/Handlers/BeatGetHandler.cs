using src.application.Beats.Command.Request;
using src.application.Beats.Command.Response;
using src.infra.data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace src.application.Beats.Handlers
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