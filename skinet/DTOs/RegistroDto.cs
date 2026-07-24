using System.ComponentModel.DataAnnotations;

namespace skinet.DTOs
{
    public class RegistroDto
    {
        [Required]
        public string nombre { get; set; } = string.Empty;
        [Required]
        public string apellido { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
