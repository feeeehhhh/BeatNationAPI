


namespace BeatNationAPI.Models
{
    public class ValueOrNumber
    {

        public bool IsIlimited{ get; set; }
        public int? Number { get; set; }
        public string Value => IsIlimited ? "Ilimited" : Number.ToString();

        public override string ToString() => Value;

        public static ValueOrNumber CreateNumber(int number)
        {
            return new ValueOrNumber { Number = number, IsIlimited = false };
        }

        public static ValueOrNumber CreateIlimited()
        {
            return new ValueOrNumber { IsIlimited = true };
        }

    }
    public class License
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public Guid? ProducerId { get; set; }

        public ValueOrNumber DurationUse { get; set; }
        public ValueOrNumber Distribution { get; set; }
        public ValueOrNumber StreamingAudio { get; set; }
        public ValueOrNumber StreamingVideo { get; set; }
        public ValueOrNumber Video { get; set; }
        public ValueOrNumber ApresenSemFinsLucrativos { get; set; }
        public ValueOrNumber ApresenFimLucrativos { get; set; }
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

