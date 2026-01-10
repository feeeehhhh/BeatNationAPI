
using BeatNationAPI.Models;

namespace BeatNationAPI.Application.Command.Licencas.Response
{
    public class LicencaCreateResponse
    {

        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public Guid? OwnerId { get; set; }
        public Guid PresetLicencaId { get; set; }
<<<<<<< HEAD
=======
        public decimal Preco { get; set; }
>>>>>>> 96a9536 (fix: fiz merda no .git da pasta e estou corrigindo mandando todas as alterçaoes em um só commit)
        public required ValorOuIlimitado PeriodoUso { get; set; }
        public required ValorOuIlimitado Distribuicao { get; set; }
        public required ValorOuIlimitado StreamingAudio { get; set; }
        public required ValorOuIlimitado StreamingVideo { get; set; }
        public required ValorOuIlimitado Video { get; set; }
        public required ValorOuIlimitado ApresenSemFinsLucrativos { get; set; }
        public required ValorOuIlimitado ApresenFimLucrativos { get; set; }
        public int Porcentagem { get; set; }
        public int RoyaltShare { get; set; }
        public bool ExibirEmissoraRadio { get; set; }
        public bool ExibirEmissoraTV { get; set; }
<<<<<<< HEAD
=======
        public bool CompartilharMp3 { get; set; } = false;
        public bool CompartilharWav { get; set; } = false;
        public bool CompartilharTrackout { get; set; } = false;
>>>>>>> 96a9536 (fix: fiz merda no .git da pasta e estou corrigindo mandando todas as alterçaoes em um só commit)

        public static implicit operator LicencaCreateResponse(Licenca l)
        {
            return new LicencaCreateResponse
            {
                Id = l.Id,
                Nome = l.Nome,
                Descricao = l.Descricao,
                Categoria = l.Categoria,
                OwnerId = l.OwnerId,
                PresetLicencaId = l.PresetLicencaId,
<<<<<<< HEAD
=======
                Preco = l.Preco,
>>>>>>> 96a9536 (fix: fiz merda no .git da pasta e estou corrigindo mandando todas as alterçaoes em um só commit)
                PeriodoUso = l.PeriodoUso,
                Distribuicao = l.Distribuicao,
                StreamingAudio = l.StreamingAudio,
                StreamingVideo = l.StreamingVideo,
                Video = l.Video,
                ApresenSemFinsLucrativos = l.ApresenSemFinsLucrativos,
                ApresenFimLucrativos = l.ApresenFimLucrativos,
<<<<<<< HEAD
                Porcentagem = l.Porcentagem,
                RoyaltShare = l.RoyaltShare,
                ExibirEmissoraRadio = l.ExibirEmissoraRadio,
                ExibirEmissoraTV = l.ExibirEmissoraTV
=======
                RoyaltShare = l.RoyaltShare,
                ExibirEmissoraRadio = l.ExibirEmissoraRadio,
                ExibirEmissoraTV = l.ExibirEmissoraTV,
                CompartilharMp3 = l.CompartilharMp3,
                CompartilharWav = l.CompartilharWav,
                CompartilharTrackout = l.CompartilharTrackout
>>>>>>> 96a9536 (fix: fiz merda no .git da pasta e estou corrigindo mandando todas as alterçaoes em um só commit)
            };
        }
    }
}
