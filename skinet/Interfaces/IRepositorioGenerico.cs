
using skinet.Entidades;

namespace skinet.Interfaces
{
    public interface IRepositorioGenerico<T> where T: EntidadBasica
    {
        Task<T?> ObtenerporidAsync(int id);
        Task<IReadOnlyList<T>> ListadoAsync();
        void Agregar(T entidad);
        void Actualizar(T entidad);
        void Borrar(T entidad);
        Task<bool> GuardarCambiosAsync();
        bool Existe(int id);
    }
}
