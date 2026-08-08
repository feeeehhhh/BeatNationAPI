using src.features.Beats.Command.Request;
using src.Data;
using MediatR;

namespace src.features.Beats.Handlers
{

    public class BeatDeleteHandler : IRequestHandler<BeatDeleteRequest>
    {
        private readonly AppDbContext _context;
        public BeatDeleteHandler(AppDbContext context)
        {
            _context = context;
        }

        public Task Handle(BeatDeleteRequest request, CancellationToken cancellationToken)
        {
            var beat = _context.Beats.Find(request.Id);
            if (beat == null)
            {
                throw new Exception("Não foi possível deletar o beat");
            }
            _context.Beats.Remove(beat);
            _context.SaveChangesAsync(cancellationToken);

            return Task.FromResult(beat.Id);
        }

        
    }

}