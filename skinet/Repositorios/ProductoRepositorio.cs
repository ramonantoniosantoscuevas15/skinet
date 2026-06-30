using Microsoft.EntityFrameworkCore;
using skinet.Entidades;
using skinet.Interfaces;

namespace skinet.Repositorios
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly AplicationDbContext context;

        public ProductoRepositorio( AplicationDbContext context)
        {
            this.context = context;
        }
        public void ActualizarProducto(Producto producto)
        {
            context.Entry(producto).State = EntityState.Modified;
        }

        public void AgregarProducto(Producto producto)
        {
            context.Productos.Add(producto);
        }

        public void BorrarProducto(Producto producto)
        {
            context.Productos.Remove(producto);
        }

        public bool ExisteProducto(int id)
        {
            return context.Productos.Any(p => p.id == id);
        }

        public async Task<Producto?> OptenerProductoporidAsync(int id)
        {
            return await context.Productos.FindAsync(id);
        }

        public async Task<IReadOnlyList<Producto>> OptenerProductosAsync()
        {
            return await context.Productos.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}
