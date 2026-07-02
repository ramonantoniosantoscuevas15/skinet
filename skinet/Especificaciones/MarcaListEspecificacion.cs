using skinet.Entidades;

namespace skinet.Especificaciones
{
    public class MarcaListEspecificacion :EspecificacionesBasicas<Producto,string>
    {
        public MarcaListEspecificacion()
        {
            AgregarSeleccion(p => p.marca);
            AplicarDistincion();
        }
    }
}
