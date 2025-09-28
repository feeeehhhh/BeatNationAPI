namespace BeatNationAPI.DTOs.Beats
{
    public class BeatLicencaCreateDto
    {
            // Id do preset ou licença padrão selecionada
            public int LicencaPresetId { get; set; }
            // Campos que o produtor pode customizar, se houver
            public decimal? PrecoCustomizado { get; set; } // opcional
            
        

    }
}
