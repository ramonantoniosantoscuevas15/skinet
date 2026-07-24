using System.ComponentModel.DataAnnotations;

namespace skinet.DTOs
{
    public class DireccionDto
    {
        [Required]
        public  string linea1 { get; set; } = string.Empty;
        
        public string? linea2 { get; set; }
        [Required]
        public string ciudad { get; set; } = string.Empty;
        [Required]
        public  string provincia { get; set; } = string.Empty;
        [Required]
        public  string codigopostal { get; set; } = string.Empty;
        [Required]
        public  string pais { get; set; } = string.Empty;
    }
}
