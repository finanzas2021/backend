using System.Collections.Generic;

namespace Finanzas.API.Domain.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        
        //REALTIONSHIP
        public Cartera Cartera { get; set; } = new Cartera();
        public IList<Recibo> Recibos { get; set; } = new List<Recibo>();
    }
}