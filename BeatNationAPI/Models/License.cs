


namespace BeatNationAPI.Models
{
    public class ValueOrIlimited
    {

        public bool IsIlimited{ get; set; }
        public int? Number { get; set; }
        public string Value => IsIlimited ? "Ilimited" : Number.ToString();

        public override string ToString() => Value;

        public static ValueOrIlimited CreateNumber(int number)
        {
            return new ValueOrIlimited { Number = number, IsIlimited = false };
        }

        public static ValueOrIlimited CreateIlimited()
        {
            return new ValueOrIlimited { IsIlimited = true };
        }

    }
    public class License
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public Guid? ProducerId { get; set; }

        public ValueOrIlimited DurationUse { get; set; }
        public ValueOrIlimited Distribution { get; set; }
        public ValueOrIlimited StreamingAudio { get; set; }
        public ValueOrIlimited StreamingVideo { get; set; }
        public ValueOrIlimited Video { get; set; }
        public ValueOrIlimited ApresenSemFinsLucrativos { get; set; }
        public ValueOrIlimited ApresenFimLucrativos { get; set; }
        public decimal Price { get; set; }
        public int RoyaltShare { get; set; }
        public bool ExibirEmissoraRadio { get; set; }
        public bool ExibirEmissoraTV { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool ShareMp3 { get; set; } = false;
        public bool ShareWav { get; set; } = false;
        public bool ShareTrackout { get; set; } = false;


    }


}

