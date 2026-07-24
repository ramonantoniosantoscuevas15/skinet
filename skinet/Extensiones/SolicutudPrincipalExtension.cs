using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using skinet.Entidades;
using System.Security.Authentication;
using System.Security.Claims;

namespace skinet.Extensiones
{
    public static class SolicutudPrincipalExtension
    {
        public static async Task<AppUsusario> GetUsuarioporEmail( this UserManager<AppUsusario> userManager, 
            ClaimsPrincipal usuario)
        {
            var user = await userManager.Users.FirstOrDefaultAsync(u => u.Email == usuario.ObtenerEmail());
            if (user == null) throw new AuthenticationException("Usuario no encontrado");

            return user;    

        }
        public static async Task<AppUsusario> GetUsuarioporEmailConDireccion(this UserManager<AppUsusario> userManager,
          ClaimsPrincipal usuario)
        {
            var user = await userManager.Users
                .Include(u => u.direccion)
                .FirstOrDefaultAsync(u => u.Email == usuario.ObtenerEmail());
            if (user == null) throw new AuthenticationException("Usuario no encontrado");

            return user;

        }

        public static string ObtenerEmail(this ClaimsPrincipal usuario)
        {
            var email = usuario.FindFirstValue(ClaimTypes.Email) ?? throw new AuthenticationException("Email solicitado no encontrado ");
            return email;
        }
    }
}
