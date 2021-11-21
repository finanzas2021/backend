namespace Finanzas.API.Resources
{
    public class CarteraResource
    {
        public int Id { get; set; }
        public float Monto { get; set; }
        
        //RELATIONSHIP
        public UsuarioResource Usuario { get; set; }
    }
}