
using BeatNationAPI.Models;

namespace BeatNationAPI.Application.Licencas.Command.Response
{
    public class PresetCreateResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Guid? OwnerId { get; set; }
        public ICollection<Licenca> Licencas { get; set; } = new List<Licenca> ();


        public static implicit operator PresetCreateResponse(PresetLicenca p)
        {
            return new PresetCreateResponse
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                OwnerId = p.OwnerId,
                Licencas = p.Licencas?
                    .Select(l => (Licenca)l) // converte cada item individualmente
                   .ToList()
            };
        }

    }
}