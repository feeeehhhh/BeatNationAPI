using System.Text.Json.Serialization;
using BeatNationAPI.Application.Beats.Command.Response;
using BeatNationAPI.Models;
using MediatR;

namespace BeatNationAPI.Application.Beats.Command.Request
{
    public class BeatColabCreateRequest : IRequest<BeatCreateResponse>
    {
        public Guid Id { get; set; }

        public Guid BeatId { get; set; } //Chave estrangeira do Beat
        
        [JsonIgnore]
        public Beat? Beat { get; set; } // agora pode ser nulo

        public string Username { get; set; } = string.Empty; // Nome do colaborador/produtor
        public int IdUsuario { get; set; }  // ID do colaborador/produtor/
        public decimal Participacao { get; set; }


        public static implicit operator BeatColab(BeatColabCreateRequest b)
        {
            return new BeatColab
            {
                Id = b.Id,
                BeatId = b.BeatId,
                Beat = b.Beat,
                Participacao = b.Participacao,
                Username = b.Username
            };
        }
    }
}