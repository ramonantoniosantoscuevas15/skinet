namespace skinet.Entidades
{
    public class Direccion : EntidadBasica
    {
        public required string linea1 { get; set; }
        public string? linea2 { get;set;}
        public required string ciudad { get;set;}
        public required string provincia { get;set;}
        public required string codigopostal { get;set;}
        public required string pais {  get;set;}
    }
}
