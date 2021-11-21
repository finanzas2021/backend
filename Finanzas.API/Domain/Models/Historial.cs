namespace Finanzas.API.Domain.Models
{
    public class Historial
    {
        public int Id { get; set; }
        
        //RELATIONSHIP
        public int CarteraId { get; set; }
        public Cartera Cartera { get; set; }
    }
}