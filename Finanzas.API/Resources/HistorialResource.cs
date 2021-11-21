namespace Finanzas.API.Resources
{
    public class HistorialResource
    {
        public int Id { get; set; }
        
        //RELATIONSHIP
        public CarteraResource Cartera { get; set; }
    }
}