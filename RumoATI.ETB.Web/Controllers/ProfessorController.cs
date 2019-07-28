using Microsoft.AspNetCore.Mvc;
using RumoATI.ETB.Domain2.Entidades;
using RumoATI.ETB.Domain2.Gerenciador;
using RumoATI.ETB.Web.Models;
using System.Linq;

namespace RumoATI.ETB.Web.Controllers
{
    public class ProfessorController : Controller
    {
        ProfessorGerenciador gerenciadorProfessor;
        public ProfessorController()
        {
            gerenciadorProfessor = new ProfessorGerenciador();
        }

        public IActionResult Index()
        {
            var professores = gerenciadorProfessor.RecuperarProfessores()
                .Select(p => new ProfessorViewModel()
                {
                    Id = p.Id,
                    SobreNome = p.SobreNome,
                    Nome = p.Nome,
                    Email = p.Email
                });

            return View(new ProfessorViewModel { Professores = professores });
        }

        [HttpPost]
        public IActionResult Add(ProfessorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var p = new Professor();
                p.Nome = model.Nome;
                p.SobreNome = model.SobreNome;
                p.Email = model.Email;

                gerenciadorProfessor.Add(p);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var p = gerenciadorProfessor.RecuperarPorId(id);

            return PartialView(p);
        }
    }
}