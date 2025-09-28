namespace BeatNationAPI.Models
{
    public class BeatColab
    {
        public int Id { get; set; }

        public Guid BeatId { get; set; } //Chave estrangeira do Beat
        public Beat Beat { get; set; }

        public Guid IdUsuario { get; set; }  // ID do colaborador/produtor/


        public decimal Participacao { get; set; }
    }
}
