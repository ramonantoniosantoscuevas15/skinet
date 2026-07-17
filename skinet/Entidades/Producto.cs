namespace skinet.Entidades
{
    public class Producto :EntidadBasica
    {
       
        public required string  nombre { get; set; } 
        public required string descripcion { get; set; } 
        public  decimal precio { get; set; }
        public required string foto { get; set; } 
        public required string tipo { get; set; } 
        public required string marca { get; set; } 
        public required  int stock { get; set; }
    }
}
