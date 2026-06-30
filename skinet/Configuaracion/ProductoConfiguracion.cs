using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using skinet.Entidades;

namespace skinet.Configuaracion
{
    public class ProductoConfiguracion : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.Property(p => p.precio).HasColumnType("decimal(18,2)");
        }
    }
}
