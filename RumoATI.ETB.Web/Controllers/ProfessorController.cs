using Microsoft.AspNetCore.Mvc;
using RumoATI.ETB.Domain2.Entidades;
using RumoATI.ETB.Domain2.Enum;
using RumoATI.ETB.Domain2.Gerenciador;
using RumoATI.ETB.Web.Models;
using System.Linq;

namespace RumoATI.ETB.Web.Controllers
{
    public class ProfessorController : BaseController
    {
        ProfessorGerenciador gerenciadorProfessor;
        CursoGerenciador gerenciadorCurso; 
        public ProfessorController()
        {
            gerenciadorProfessor = new ProfessorGerenciador();
            gerenciadorCurso     = new CursoGerenciador();
        }

        public IActionResult Index()
        {
            var professores = gerenciadorProfessor.RecuperarProfessores()
                .Select(p => new ProfessorViewModel()
                {
                    Id        = p.Id,
                    SobreNome = p.SobreNome,
                    Nome      = p.Nome,
                    Email     = p.Email
                });

            var model         = new ProfessorViewModel();
            model.Cursos      = gerenciadorCurso.RecuperarCursos();
            model.Professores = professores;

            return View(model);
        }

        [HttpGet]
        public IActionResult Add(int Id)
        {
            var p = gerenciadorProfessor.RecuperarPorId(Id);
            var model = new ProfessorViewModel
            {
                Id = p.Id,
                Nome = p.Nome,
                SobreNome = p.SobreNome,
                Email = p.Email,
                Cursos = gerenciadorCurso.RecuperarCursos(),
                CursoSelecionados = p.ProfessoresCurso.Select(cs => cs.IdCurso).ToArray()
            };

            return PartialView(model);
        }

        [HttpPost]
        public IActionResult Add(ProfessorViewModel model)
        {
            if (ModelState.IsValid)
            {
                Professor p = null;

                if (model.Id > 0)
                    p = gerenciadorProfessor.RecuperarPorId(model.Id);
                else
                {
                    p = new Professor();
                    p.Usuario = new Usuario();
                    p.Usuario.IdPerfil = (int)EPerfil.Professor;
                    p.Usuario.Nome = model.Nome;
                }

                p.Nome      = model.Nome;
                p.SobreNome = model.SobreNome;
                p.Email     = model.Email;

                if (model.CursoSelecionados != null && model.CursoSelecionados.Length > 0)
                {
                    foreach (var cs in model.CursoSelecionados)
                    {
                        p.ProfessoresCurso.Add(new ProfessorCurso { IdCurso = cs, Professor = p });
                    }
                }

                gerenciadorProfessor.Add(p);
            }

            return RedirectToAction("Index");
        }
    }
}