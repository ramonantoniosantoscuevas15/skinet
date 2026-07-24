using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using skinet.Configuaracion;
using skinet.Entidades;

namespace skinet
{
    public class AplicationDbContext : IdentityDbContext<AppUsusario>
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
        public DbSet<Direccion> Direcciones { get; set; }
    }
}
