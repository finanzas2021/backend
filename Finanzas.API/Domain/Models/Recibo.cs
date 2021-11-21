namespace Finanzas.API.Domain.Models
{
    public class Recibo
    {
        public int Id { get; set; }
        public int HistorialId { get; set; }
        public Historial Historial { get; set; }
        //ENTRADA
        public int UsuarioId { get; set; }// R
        public Usuario Usuario { get; set; }// R
        public string F_Emision { get; set; }
        public string F_Pago { get; set; }
        public bool Moneda { get; set; }
        public float Monto { get; set; }
        public bool T_Tasa { get; set; }
        public decimal Tasa { get; set; }
        public string Plazo_Tasa { get; set; }
        //INTERMEDIOS
        public float G_Iniciales { get; set; }
        public float G_Finales { get; set; }
        //FINALES
        public float Monto_Cobrar { get; set; }
        public float V_Entregado { get; set; }
        public decimal TCEA { get; set; }
        public int N_Dias { get; set; }
        public decimal T_Descontada { get; set; }
        public float V_Neto { get; set; }
        public decimal Descuento { get; set; }
    }
}