using System.ComponentModel.DataAnnotations;

namespace Finanzas.API.Resources
{
    public class SaveCarteraResource
    {
        [Required]
        public float Monto { get; set; }
        
        //RELATIONSHIP
        [Required]
        public int UsuarioId { get; set; }
    }
}