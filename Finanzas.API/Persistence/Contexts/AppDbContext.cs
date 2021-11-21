using System.Threading.Tasks;
using Finanzas.API.Domain.Models;
using Finanzas.API.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Finanzas.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        
        public DbSet<Cartera> Carteras { get; set; }
        
        public DbSet<Historial> Historiales { get; set; }
        
        public DbSet<Recibo> Recibos { get; set; }
        

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Constraints
            //INICIOS
            builder.Entity<Recibo>().ToTable("Recibos");
            builder.Entity<Recibo>().HasKey(p => p.Id);
            builder.Entity<Recibo>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Recibo>().Property(p => p.F_Emision);
            builder.Entity<Recibo>().Property(p => p.F_Pago);
            builder.Entity<Recibo>().Property(p => p.Moneda);
            builder.Entity<Recibo>().Property(p => p.Monto);
            builder.Entity<Recibo>().Property(p => p.T_Tasa);
            builder.Entity<Recibo>().Property(p => p.Tasa);
            builder.Entity<Recibo>().Property(p => p.Plazo_Tasa);
            //INTERMEDIOS
            builder.Entity<Recibo>().Property(p => p.G_Iniciales);
            builder.Entity<Recibo>().Property(p => p.G_Finales);
            //FINALES
            builder.Entity<Recibo>().Property(p => p.Monto_Cobrar);
            builder.Entity<Recibo>().Property(p => p.V_Entregado);
            builder.Entity<Recibo>().Property(p => p.TCEA);
            builder.Entity<Recibo>().Property(p => p.N_Dias);
            builder.Entity<Recibo>().Property(p => p.T_Descontada);
            builder.Entity<Recibo>().Property(p => p.V_Neto);
            builder.Entity<Recibo>().Property(p => p.Descuento);
            
            // Constraints
            builder.Entity<Historial>().ToTable("Historiales");
            builder.Entity<Historial>().HasKey(p => p.Id);
            builder.Entity<Historial>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

            // Constraints
            builder.Entity<Cartera>().ToTable("Carteras");
            builder.Entity<Cartera>().HasKey(p => p.Id);
            builder.Entity<Cartera>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Cartera>().Property(p => p.Monto).IsRequired();

            // Relationships
            builder.Entity<Usuario>()
                .HasOne(p => p.Cartera)
                .WithOne(p => p.Usuario)
                .HasForeignKey<Cartera>(p => p.UsuarioId);

            builder.Entity<Cartera>()
                .HasOne(p => p.Historial)
                .WithOne(p => p.Cartera)
                .HasForeignKey<Historial>(p => p.CarteraId);

            builder.Entity<Usuario>()
                .HasMany(p => p.Recibos)
                .WithOne(p => p.Usuario)
                .HasForeignKey(p => p.UsuarioId);
            
            // Seed Data

            
            // Constraints
            builder.Entity<Usuario>().ToTable("Usuarios");
            builder.Entity<Usuario>().HasKey(p => p.Id);
            builder.Entity<Usuario>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Usuario>().Property(p => p.Name).IsRequired();
            builder.Entity<Usuario>().Property(p => p.Username).IsRequired();
            builder.Entity<Usuario>().Property(p => p.Password).IsRequired();
            builder.Entity<Usuario>().Property(p => p.Email).IsRequired();
            
            builder.UseSnakeCaseNamingConvention();
        }
    }
}