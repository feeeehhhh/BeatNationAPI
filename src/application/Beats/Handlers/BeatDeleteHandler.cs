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

        public async Task Handle(BeatDeleteRequest request, CancellationToken cancellationToken)
        {

            var beat = await _context.Beats.FindAsync(
                   new object[] { request.Id },
                   cancellationToken
               );

            if (beat == null)
            {
                throw new Exception("Não foi possível deletar o beat");
            }

            var uploadsPath = "/mnt/uploads";

            DeleteFile(uploadsPath, beat.UrlMp3);
            DeleteFile(uploadsPath, beat.UrlWav);
            DeleteFile(uploadsPath, beat.UrlTrackout);
            DeleteFile(uploadsPath, beat.UrlCover);

            _context.Beats.Remove(beat);
            await _context.SaveChangesAsync(cancellationToken);
        }
        private static void DeleteFile(string uploadsPath, string? fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return;
            }

            var filePath = Path.Combine(uploadsPath, fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

    }

}