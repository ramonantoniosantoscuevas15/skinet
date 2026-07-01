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

        public async Task<IReadOnlyList<string>> ObtenerMarcaAsync()
        {
            return await context.Productos.Select(m => m.marca).Distinct().ToListAsync();
        }

        

        public async Task<IReadOnlyList<Producto>> ObtenerProductosAsync(string? marca, string? tipo,string? orden)
        {
            var query = context.Productos.AsQueryable();
            if(!string.IsNullOrEmpty(marca))
            {
                query = query.Where(p => p.marca == marca);
            }
            if(!string.IsNullOrEmpty(tipo))
            {
                query = query.Where(p => p.tipo == tipo);
            }
            if (!string.IsNullOrEmpty(orden))
            {
                query = orden switch
                {
                    "precioAsc" => query.OrderBy(p => p.precio),
                    "precioDesc" => query.OrderByDescending(p => p.precio),
                    _ => query.OrderBy(p => p.nombre)
                };
            }
            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<string>> ObtenerTipoAsync()
        {
            return await context.Productos.Select(m => m.tipo).Distinct().ToListAsync();
        }

        public async Task<Producto?> OptenerProductoporidAsync(int id)
        {
            return await context.Productos.FindAsync(id);
        }

        

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}
