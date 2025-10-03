using System.Threading.Tasks;
using BeatNationAPI.Application.Beats.Command.Request;
using BeatNationAPI.Application.Beats.Command.Response;
using BeatNationAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace BeatNationAPI.Application.Handlers
{
    public class BeatCreateHandler
    {
        private readonly AppDbContext _context;


        public async Task<BeatCreateResponse> Handle(BeatCreateRequest request)
        {
            var isAlready = await _context.Beats
            .FirstOrDefaultAsync(b => b.Nome == request.Nome
                                    || b.ISRC == request.ISRC);

            if (isAlready != null)
            {
                if (isAlready.Nome == request.Nome)
                {
                    throw new InvalidOperationException("Já existe um Beat cadastrado com esse nome !");
                }
                if (isAlready.ISRC == request.ISRC)
                {
                    throw new InvalidOperationException("Já existe um Beat cadastrado com esse ISRC !");
                }
            }










        }
    }
}