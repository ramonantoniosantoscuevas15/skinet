namespace skinet.RequestHelpers
{
    public class Paginacion<T>(int paginaIndex, int cantidadPagina, int total, IReadOnlyList<T> datos)
    {
        public int CantidadPagina { get; set; } = cantidadPagina;
        public int PaginaIndex { get; set; } = paginaIndex;
        
        public int Total { get; set; } = total;
        public IReadOnlyList<T> Datos { get; set; } = datos;
    }
}
