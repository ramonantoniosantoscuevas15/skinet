using skinet.Entidades;

namespace skinet.Especificaciones
{
    public class ProductoEspecificacion : EspecificacionesBasicas<Producto>
    {
        public ProductoEspecificacion(string? marca,string?tipo,string?orden) : base(p =>
        (string.IsNullOrWhiteSpace(marca) || p.marca == marca) && 
        (string.IsNullOrWhiteSpace(tipo) || p.tipo == tipo)
            )
        {
            switch(orden)
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
