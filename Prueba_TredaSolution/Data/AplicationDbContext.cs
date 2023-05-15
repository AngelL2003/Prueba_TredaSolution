using Microsoft.EntityFrameworkCore;
using Prueba_Tecnica_Treda.Entidades;


namespace Prueba_TredaSolution.Data
{
    public class AplicationDbContext : DbContext
    {
        private readonly DbContextOptions<AplicationDbContext> options;

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
            this.options = options;
        }


        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Tienda>().ToTable("Tienda");
            //modelBuilder.Entity<Producto>().ToTable("Producto");

            modelBuilder.Entity<Producto>().HasKey(p => p.SKU);

            //Modifica la propiedad de FechaDeApertura de DateTime a Date
            modelBuilder.Entity<Tienda>().Property(t => t.FechaDeApertura).HasColumnType("date");

            //Modifica la propiedad de Imagen a obligatoria y sin caracteres unicode
            modelBuilder.Entity<Producto>().Property(t => t.Imagen).IsRequired().IsUnicode(false);

            //Modifica la propiedad de Valor para ser mas exacto con los decimales
            modelBuilder.Entity<Producto>().Property(p => p.SKU).HasPrecision(18, 2);




        }

    }
}
