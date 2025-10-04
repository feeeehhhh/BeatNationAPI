using System.Threading.Tasks;
using BeatNationAPI.Application.Beats.Command.Request;
using BeatNationAPI.Application.Beats.Command.Response;
using BeatNationAPI.Data;
using BeatNationAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BeatNationAPI.Application.Handlers
{
     public class BeatCreateHandler : IRequest<BeatColabCreateRequest, BeatCreatePrivateResponse>
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BeatCreateHandler(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

       public async Task<BeatCreatePrivateResponse> Handle(BeatCreateRequest request)
        {



            // Verifica se o beat já existe
            var isAlready = await _context.Beat
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

            // Pega o id do IdUsuario via Token
            var currentUserIdString = _httpContextAccessor.HttpContext.User
            .FindFirst("id")?.Value; ;
            // faz a conversão do string para Guid
            if (!Guid.TryParse(currentUserIdString, out Guid currentUserId))
            {
                throw new UnauthorizedAccessException("Token inválido ou ausente");
            }

            //setar no request
            request.OwnerId = currentUserId;
            Beat beat = request;
            beat.CriadoEm = DateTime.UtcNow;
            beat.AtualizadoEm = DateTime.UtcNow;

            await _context.AddAsync(beat);
            await _context.SaveChangesAsync();

            
            if (currentUserId == beat.OwnerId)
            {
                return (BeatCreatePrivateResponse)beat;
            }
         
        }


    }

    public interface IRequest<T1, T2>
    {
    }
}