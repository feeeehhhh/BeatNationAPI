using src.application.Beats.Command.Request;
using src.infra.data;
using MediatR;

namespace src.application.Beats.Handlers
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

            //TODO: Implementar a exclusão arquivos armazenados no docker

            return Task.FromResult(beat.Id);
        }

        
    }

}