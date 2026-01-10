
using System.Text.Json.Serialization;
<<<<<<< HEAD
=======
using BeatNationAPI.Application.Command.Licencas.Response;
>>>>>>> 96a9536 (fix: fiz merda no .git da pasta e estou corrigindo mandando todas as alterçaoes em um só commit)
using BeatNationAPI.Models;

namespace BeatNationAPI.Application.Licencas.Command.Response
{
    public class PresetCreateResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Guid? OwnerId { get; set; }
<<<<<<< HEAD
        
        public ICollection<Licenca> Licencas { get; set; } = new List<Licenca>();
=======

        public ICollection<LicencaCreateResponse> Licencas { get; set; } = new List<LicencaCreateResponse>();
>>>>>>> 96a9536 (fix: fiz merda no .git da pasta e estou corrigindo mandando todas as alterçaoes em um só commit)


        public static implicit operator PresetCreateResponse(PresetLicenca p)
        {
            return new PresetCreateResponse
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                OwnerId = p.OwnerId,
                Licencas = p.Licencas?
<<<<<<< HEAD
                    .Select(l => (Licenca)l) // converte cada item individualmente
=======
                    .Select(l => (LicencaCreateResponse)l) // converte cada item individualmente
>>>>>>> 96a9536 (fix: fiz merda no .git da pasta e estou corrigindo mandando todas as alterçaoes em um só commit)
                   .ToList()
            };
        }

    }
}