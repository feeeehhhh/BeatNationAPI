using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

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
    public class LicencaConfig
    {
        public Guid Id { get; set; }
        public Guid LicencaId { get; set; }

        [JsonIgnore]
        public Licenca? Licenca { get; set; }
        public required ValorOuIlimitado PeriodoUso { get; set; }
        public required ValorOuIlimitado Distribuicao { get; set; }
        public required ValorOuIlimitado StreamingAudio { get; set; }
        public required ValorOuIlimitado StreamingVideo { get; set; }
        public required ValorOuIlimitado Video { get; set; }
        public required ValorOuIlimitado ApresenSemFinsLucrativos { get; set; }
        public required ValorOuIlimitado ApresenFimLucrativos { get; set; }
        public int Preco { get; set; }
        public int Porcentagem { get; set; }
        public int RoyaltShare { get; set; }
        public bool ExibirEmissoraRadio { get; set; }
        public bool ExibirEmissoraTV { get; set; }
    }

}

