using System.ComponentModel.DataAnnotations;

namespace Finanzas.API.Resources
{
    public class SaveUsuarioResource
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        [Required]
        public string Email { get; set; }
    }
}