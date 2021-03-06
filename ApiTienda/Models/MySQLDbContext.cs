using Microsoft.EntityFrameworkCore;
using API_Tienda.Models;

namespace API_Tienda.Models
{

    // Contexto de la Base de datos
    public class MySQLDbContext : DbContext
    {
        public MySQLDbContext(DbContextOptions<MySQLDbContext> options)
            : base(options)
        {
        }

        // El campo debe tener el mismo nombre que la tabla de la BD
        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<Localidad> Localidad { get; set; }
        public DbSet<TipoArticulo> TipoArticulo { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Linped> Linped { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Camara> Camara { get; set; }
        public DbSet<Memoria> Memoria { get; set; }
        public DbSet<Objetivo> Objetivo { get; set; }
        public DbSet<Tv> Tv { get; set; }

        // Clave primaria compuesta de linped
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Linped>()
                .HasKey(l => new { l.PedidoID, l.Linea });

            modelBuilder.Entity<Localidad>()
                .HasKey(lo => new { lo.ProvinciaID, lo.LocalidadID });
        }
    }
}
