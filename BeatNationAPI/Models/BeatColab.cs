namespace BeatNationAPI.Models
{
    public class BeatColab
    {
        public int Id { get; set; }

        public int BeatId { get; set; } //Chave estrangeira do Beat
        public Beat Beat { get; set; }

        public int IdUsuario { get; set; }  // ID do colaborador/produtor/


        public decimal Participacao { get; set; }
    }
}
