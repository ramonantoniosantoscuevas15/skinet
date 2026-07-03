
using skinet.Entidades;


namespace skinet.Interfaces
{
    public interface IRepositorioGenerico<T> where T: EntidadBasica
    {
        Task<T?> ObtenerporidAsync(int id);
        Task<IReadOnlyList<T>> ListadotodoAsync();
        Task<T?> ObtenerentidadconEspec(IEspecificacion<T> espec);
        Task<IReadOnlyList<T>> ListaAsync(IEspecificacion<T> espec);
        Task<TResult?> ObtenerentidadconEspec<TResult>(IEspecificacion<T,TResult> espec);
        Task<IReadOnlyList<TResult>> ListaAsync<TResult>(IEspecificacion<T,TResult> espec);
        void Agregar(T entidad);
        void Actualizar(T entidad);
        void Borrar(T entidad);
        Task<bool> GuardarCambiosAsync();
        bool Existe(int id);
        Task<int> TotalAsync(IEspecificacion<T> espec);

    }
}
