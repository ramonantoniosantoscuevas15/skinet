using skinet.Entidades;

namespace skinet.Especificaciones
{
    public class TipoListEspecificacion : EspecificacionesBasicas<Producto,string>
    {
        public TipoListEspecificacion()
        {
            AgregarSeleccion(p => p.tipo);
            AplicarDistincion();
        }
    }
}
