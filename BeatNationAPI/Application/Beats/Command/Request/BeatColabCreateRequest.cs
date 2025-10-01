namespace BeatNationAPI.Application.Beats.Command.Request
{
    public class BeatColabCreateRequest
    {
        public Guid IdUsuario { get; set; }      // ID do colaborador
        public decimal Participacao { get; set; } // Percentual de participação

    }
}