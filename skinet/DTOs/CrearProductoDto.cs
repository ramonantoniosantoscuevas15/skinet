using System.ComponentModel.DataAnnotations;

namespace skinet.DTOs
{
    public class CrearProductoDto
    {
        [Required]
        public  string nombre { get; set; } = string.Empty;
        [Required]
        public  string descripcion { get; set; } = string.Empty;
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
        public decimal precio { get; set; }
        [Required]
        public  string foto { get; set; } = string.Empty;
        [Required]
        public  string tipo { get; set; } = string.Empty;
        [Required]
        public  string marca { get; set; } = string.Empty;
        [Required]
        public int stock { get; set; } 
    }
}
