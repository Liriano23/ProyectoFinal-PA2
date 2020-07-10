using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoFinal_PA2.Models;
using ProyectoFinal_PA2.BLL;
using ProyectoFinal_PA2.DAL;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace ProyectoFinal_PA2.Pages
{
    public class LoginModel : PageModel
    {
        ToastService ToastService = new ToastService();
        public string ReturnUrl { get; set; }
        Usuarios Usuarios = new Usuarios();
        
        Contexto contexto = new Contexto();
        List<Usuarios> ListaUsuarios = new List<Usuarios>();


        public async Task<ActionResult> OnGetAsync(string paramUsername, string paramPassword)
        {
            string returnUrl = Url.Content("~/");
            try
            {
                // Clear the existing external cookie
                await HttpContext
                    .SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch { }
            // *** !!! This is where you would validate the user !!! ***
            // In this example we just log the user in
            // (Always log the user in for this demo)

            if (UsuariosBLL.GetExistenciaYClaveUsuario(paramUsername, paramPassword))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, paramUsername),
                    new Claim(ClaimTypes.Role, UsuariosBLL.GetTipoUsuario(paramUsername))

                };
                var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    RedirectUri = this.Request.Host.Value
                };
                try
                {
                    await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                }
            }
            return LocalRedirect(returnUrl);
        }
    }
}
