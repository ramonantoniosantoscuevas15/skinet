using Microsoft.AspNetCore.Identity;

namespace skinet.Entidades
{
    public class AppUsusario : IdentityUser
    {
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public Direccion? direccion { get; set; }
    }
}
