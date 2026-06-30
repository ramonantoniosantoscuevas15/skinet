using skinet.Entidades;

namespace skinet.Interfaces
{
    public interface IProductoRepositorio
    {
        Task<IReadOnlyList<Producto>> OptenerProductosAsync();
        Task<Producto?> OptenerProductoporidAsync(int id);
        void AgregarProducto(Producto producto);
        void ActualizarProducto(Producto producto);
        void BorrarProducto(Producto producto);
        bool ExisteProducto(int id);
        Task<bool> SaveChangesAsync();  
    }
}
