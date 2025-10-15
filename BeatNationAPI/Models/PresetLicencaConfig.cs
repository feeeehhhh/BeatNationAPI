using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace BeatNationAPI.Models
{
    
    public class ValorOuIlimitado
    {

        public string Valor { get; set; }
        public bool IsIlimitado => Valor?.Equals("Ilimitado", StringComparison.OrdinalIgnoreCase) == true;
        public int? Numero
        {
            get
            {
                if (int.TryParse(Valor, out var numero))
                    return numero;
                return null;
            }
        }
        public static ValorOuIlimitado CriarIlimitado()
        {
            return new ValorOuIlimitado { Valor = "Ilimitado" };
        }
        public static ValorOuIlimitado CriarComNumero(int numero)
        {
            return new ValorOuIlimitado { Valor = numero.ToString() };
        }
        public override string ToString() => Valor ?? "0";
        public static implicit operator ValorOuIlimitado(int numero)
        {
            return new ValorOuIlimitado { Valor = numero.ToString() };
        }
        public static implicit operator ValorOuIlimitado(string valor)
        {
            return new ValorOuIlimitado { Valor = valor };
        }

    }
    public class PresetLicencaConfig
    {


        public Guid Id { get; set; }

        public Guid PresetLicencaId { get; set; }
        public string LicencaNome { get; set; }

        [JsonIgnore] // Evita referência circular na serialização JSON
        public PresetLicenca PresetLicenca { get; set; }

        public Guid LicencasId { get; set; }

        [JsonIgnore]
        public Licencas Licencas { get; set; }

        // Configurações do preset

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

