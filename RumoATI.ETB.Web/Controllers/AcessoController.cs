using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RumoATI.ETB.Web.Models;

namespace RumoATI.ETB.Web.Controllers
{
    public class AcessoController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Messagem = "Informe os parâmetros";
                return View(model);
            }

            return View();
        }
    }
}