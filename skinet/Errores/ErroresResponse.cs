namespace skinet.Errores
{
    public class ErroresResponse(int codigostatus, string mensage, string? descripcion)
    {
        public int codigostatus { get; set; } = codigostatus;
        public string mensage { get; set; } = mensage;
        public string? descripcion { get; set; } = descripcion;
    }
}
