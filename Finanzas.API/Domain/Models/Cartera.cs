namespace Finanzas.API.Domain.Models
{
    public class Cartera
    {
        public int Id { get; set; }
        public float Monto { get; set; }
        
        //RELATIONSHIP
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public Historial Historial { get; set; } = new Historial();

    }
}