using skinet.Entidades;

namespace skinet.Especificaciones
{
    public class ProductoEspecificacion : EspecificacionesBasicas<Producto>
    {
        public ProductoEspecificacion(ProductoEspecificacionParametros parametros) : base(p =>
        (string.IsNullOrEmpty(parametros.Buscar) || p.nombre.ToLower().Contains(parametros.Buscar)) &&
        (parametros.marcas.Count == 0 || parametros.marcas.Contains(p.marca)) &&
        (parametros.tipos.Count ==0 || parametros.tipos.Contains(p.tipo))
            )
        {
            AplicarPaginacion(parametros.CantidadPagina * (parametros.paginaIndex -1),parametros.CantidadPagina); 
            switch (parametros.orden)
            {
                case "precioAsc":
                    AgregarOrdenarpor(p => p.precio);
                break;
                    case "precioDesc":
                    AgregarOrdenarporDesc(p => p.precio);
                    break;
                default:
                    AgregarOrdenarpor(p => p.nombre);
                    break;
            }
            
        }
    }
}
