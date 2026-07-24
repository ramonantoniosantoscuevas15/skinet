using skinet.DTOs;
using skinet.Entidades;

namespace skinet.Extensiones
{
    public static class DireccionMappingExtension
    {
        public static DireccionDto? ADto(this Direccion? direccion)
        {
            if (direccion == null) return null;

            return new DireccionDto
            {
                linea1 = direccion.linea1,
                linea2 = direccion.linea2,
                ciudad = direccion.ciudad,
                provincia = direccion.provincia,
                pais = direccion.pais,
                codigopostal = direccion.codigopostal,

            };
        }

        public static Direccion AEntidad(this DireccionDto direccionDto)
        {
            if (direccionDto == null) throw new ArgumentNullException(nameof(direccionDto));

            return new Direccion
            {
                linea1 = direccionDto.linea1,
                linea2 = direccionDto.linea2,
                ciudad = direccionDto.ciudad,
                provincia = direccionDto.provincia,
                pais = direccionDto.pais,
                codigopostal = direccionDto.codigopostal,

            };
        }

        public static void ActualizarDeDto(this Direccion direccion, DireccionDto direccionDto)
        {
            if (direccionDto == null) throw new ArgumentNullException(nameof(direccionDto));
            if (direccion == null) throw new ArgumentNullException(nameof(direccion));



            direccion.linea1 = direccionDto.linea1;
            direccion.linea2 = direccionDto.linea2;
            direccion.ciudad = direccionDto.ciudad;
            direccion.provincia = direccionDto.provincia;
            direccion.pais = direccionDto.pais;
            direccion.codigopostal = direccionDto.codigopostal;

            
        }
    }
}
