using BeatNationAPI.Application.Licencas.Command.Request;
using BeatNationAPI.Data;
using MediatR;

namespace BeatNationAPI.Application.Licencas.Handlers
{
    public class LicencaDeleteHandler : IRequestHandler<LicencaDeleteRequest>
    {
        private readonly AppDbContext _context;
        public LicencaDeleteHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(LicencaDeleteRequest request, CancellationToken cancellationToken)
        {
            var licenca = await _context.Licencas.FindAsync(request.Id);
            if (licenca == null)
            {
                throw new Exception("Não foi possível deletar a licença");
            }

            _context.Licencas.Remove(licenca);
            await _context.SaveChangesAsync(cancellationToken);

            return licenca.Id; 
        }

        Task IRequestHandler<LicencaDeleteRequest>.Handle(LicencaDeleteRequest request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
}