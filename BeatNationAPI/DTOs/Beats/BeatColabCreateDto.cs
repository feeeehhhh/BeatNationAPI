namespace BeatNationAPI.DTOs.Beats
{
    public class BeatColabCreateDto
    {
        public Guid IdUsuario { get; set; }      // ID do colaborador
        public decimal Participacao { get; set; } // Percentual de participação
    }
}
