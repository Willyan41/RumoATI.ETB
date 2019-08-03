using Microsoft.AspNetCore.Mvc;
using RumoATI.ETB.Domain2.Entidades;
using RumoATI.ETB.Domain2.Gerenciador;
using RumoATI.ETB.Web.Models;
using System.Linq;

namespace RumoATI.ETB.Web.Controllers
{
    public class CursoController : Controller
    {
        CursoGerenciador gerenciadorCurso;

        public CursoController()
        {
            gerenciadorCurso = new CursoGerenciador();
        }
    }
}