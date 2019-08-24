using RumoATI.ETB.Domain2.Context;
using RumoATI.ETB.Domain2.Entidades;
using System;
using System.Linq;
using umoATI.ETB.Domain2.Entidades;

namespace RumoATI.ETB.Domain2.Gerenciador
{
    public class CursoGerenciador : GerenciadorBase
    {
        public CursoGerenciador()
        {
            _context = new ETBContext();
        }
        public void Add(Curso curso)
        {
            try
            {
                if (curso != null)
                {
                    if (curso.Id == 0)
                        _context.Curso.Add(curso);

                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Curso RecuperarPorID(int id)
        {
            return _context.Curso.Find(id);

        }
        public IQueryable<Curso> RecuperarCurso()
        {
            return _context.Curso.Select(p => new Curso
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao
            });           
        }

        public void Delete(Curso curso)
        {
            try
            {
                if (curso != null)
                {
                    _context.Curso.Remove(curso);

                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
  }
