using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RumoATI.ETB.Domain2.Gerenciador;
using RumoATI.ETB.Domain2.Seguranca;
using RumoATI.ETB.Web.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RumoATI.ETB.Web.Controllers
{
    public class AcessoController : BaseController
    {
        UsuarioGerenciador usuarioGerenciador;

        public AcessoController()
        {
            usuarioGerenciador = new UsuarioGerenciador();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous, HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Messagem = "Informe os parâmetros";
                return View(model);
            }

            var resp = new Responsavel(model.Login, model.Password);

            if (usuarioGerenciador.AutorizarUsuario(resp))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Login)
                };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                return Redirect("/Home/Index");
            }
            else
            {
                model.Messagem = "Usuário/Senha inválidos";
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
                await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Acesso");
        }
    }
}