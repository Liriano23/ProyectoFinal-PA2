using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoFinal_PA2.Models;
using ProyectoFinal_PA2.BLL;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace ProyectoFinal_PA2.Pages
{
    public class LoginModel : PageModel
    {
        
        Usuarios Usuarios = new Usuarios();
        List<Usuarios> ListaUsuarios = new List<Usuarios>();


        public async Task<ActionResult> OnGetAsync(string paramUsername, string paramPassword)
        {
            string returnUrl = Url.Content("/RedireccionLogin");
            
            try
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch 
            {
                throw;
            }

            if (UsuariosBLL.GetExistenciaYClaveUsuario(paramUsername, paramPassword))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, paramUsername),
                    new Claim(ClaimTypes.Role, UsuariosBLL.GetTipoUsuario(paramUsername))

                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    RedirectUri = this.Request.Host.Value
                };
                try
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),authProperties);
                }
                catch (Exception)
                {
                    throw;
                }
                return LocalRedirect("/");
            }
            else
            {
                return LocalRedirect(returnUrl);
            }
        }
    }
}
