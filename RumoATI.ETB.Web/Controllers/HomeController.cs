using Microsoft.AspNetCore.Mvc;
using RumoATI.ETB.Domain2.Gerenciador;

namespace RumoATI.ETB.Web.Controllers
{
    public class HomeController : BaseController
    {
        CursoGerenciador gerenciadorCurso;

        public HomeController()
        {
            gerenciadorCurso = new CursoGerenciador();
        }

        public IActionResult Index()
        {
            return View(gerenciadorCurso.RecuperarCursos());
        }
    }
}