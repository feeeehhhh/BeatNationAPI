

using System.Text.Json.Serialization;

namespace BeatNationAPI.Models
{


    public class ValorOuIlimitado
    {


        public bool IsIlimitado { get; set; }
        public int? Numero { get; set; }
        public string Valor => IsIlimitado ? "Ilimitado" : Numero.ToString();

        public override string ToString() => Valor;

        public static ValorOuIlimitado CriarComNumero(int numero)
        {
            return new ValorOuIlimitado { Numero = numero, IsIlimitado = false };
        }

        public static ValorOuIlimitado CriarIlimitado()
        {
            return new ValorOuIlimitado { IsIlimitado = true };
        }

    }
    public class Licenca
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public Guid? OwnerId { get; set; }

        public Guid PresetLicencaId { get; set; }

        public  ValorOuIlimitado PeriodoUso { get; set; }
        public  ValorOuIlimitado Distribuicao { get; set; }
        public ValorOuIlimitado StreamingAudio { get; set; }
        public ValorOuIlimitado StreamingVideo { get; set; }
        public  ValorOuIlimitado Video { get; set; }
        public  ValorOuIlimitado ApresenSemFinsLucrativos { get; set; }
        public  ValorOuIlimitado ApresenFimLucrativos { get; set; }
        public int Porcentagem { get; set; }
        public int RoyaltShare { get; set; }
        public bool ExibirEmissoraRadio { get; set; }
        public bool ExibirEmissoraTV { get; set; }

        [JsonIgnore] // Evita referência circular na serialização JSON
        public PresetLicenca? PresetLicenca { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }


    }


}

