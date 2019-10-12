using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RumoATI.ETB.Domain2.Gerenciador;
using RumoATI.ETB.Web.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using RumoATI.ETB.Domain2.Entidades;

namespace RumoATI.ETB.Web.Controllers
{
    public class CursoController : BaseController
    {
        CursoGerenciador gerenciadorCurso;
        private IHostingEnvironment _env;

        public CursoController(IHostingEnvironment env)
        {
            gerenciadorCurso = new CursoGerenciador();
            _env = env;
        }
        public IActionResult Index()
        {
            var cursos = gerenciadorCurso.RecuperarCursos()
                .Select(c => new CursoViewModel()
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Descricao = c.Descricao
                });

            var model = new CursoViewModel { Cursos = cursos };

            return View(model);
        }

        [HttpGet]
        public IActionResult Add(int Id)
        {
            var c = gerenciadorCurso.RecuperarPorID(Id);
            var model = new CursoViewModel
            {
                Id = c.Id,
                Nome = c.Nome,
                Descricao = c.Descricao
            };

            return PartialView(model);
        }

        [HttpPost]
        public async Task<ActionResult> Add(CursoViewModel model)
        {
            if (ModelState.IsValid)
            {
                Curso c = null;

                if (model.Id > 0)
                    c = gerenciadorCurso.RecuperarPorID(model.Id);
                else
                    c = new Curso();

                c.Nome = model.Nome;
                c.Descricao = model.Descricao;

                var root = _env.WebRootPath;
                var path = Path.Combine(root, "imagens\\curso");
                var name = Guid.NewGuid().ToString() + "_" + model.Foto.FileName;
                var filePath = Path.Combine(path, name);

                c.PathFoto = name;

                if (Directory.Exists(path))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Foto.CopyToAsync(stream);
                    }
                }

                gerenciadorCurso.Add(c);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var curso = gerenciadorCurso.RecuperarPorID(id);

            if (curso != null)
            {
                gerenciadorCurso.Delete(curso);

                var cursos = gerenciadorCurso.RecuperarCursos()
                                .Select(c => new CursoViewModel()
                                {
                                    Id = c.Id,
                                    Nome = c.Nome,
                                    Descricao = c.Descricao
                                });

                return PartialView("Cursos", cursos);
            }

            return BadRequest("Erro ao deletar Curso");
        }
    }
}