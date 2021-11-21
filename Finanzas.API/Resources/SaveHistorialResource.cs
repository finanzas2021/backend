using System.ComponentModel.DataAnnotations;

namespace Finanzas.API.Resources
{
    public class SaveHistorialResource
    {
        //RELATIONSHIP
        [Required]
        public int CarteraId { get; set; }
    }
}