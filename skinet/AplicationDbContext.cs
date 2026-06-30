using Microsoft.EntityFrameworkCore;
using skinet.Configuaracion;
using skinet.Entidades;

namespace skinet
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductoConfiguracion).Assembly);
            


        }
        public DbSet<Producto> Productos { get; set; }
    }
}
