using skinet.Entidades;

namespace skinet.Interfaces
{
    public interface IProductoRepositorio
    {
        Task<IReadOnlyList<Producto>> ObtenerProductosAsync(string? marca, string? tipo, string? orden);
        Task<Producto?> OptenerProductoporidAsync(int id);
        Task<IReadOnlyList<string>> ObtenerMarcaAsync();
        Task<IReadOnlyList<string>> ObtenerTipoAsync();
        void AgregarProducto(Producto producto);
        void ActualizarProducto(Producto producto);
        void BorrarProducto(Producto producto);
        bool ExisteProducto(int id);
        Task<bool> SaveChangesAsync();  
    }
}
