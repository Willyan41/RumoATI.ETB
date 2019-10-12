using RumoATI.ETB.Domain2.Context;
using RumoATI.ETB.Domain2.Entidades;
using System;
using System.Linq;

namespace RumoATI.ETB.Domain2.Gerenciador
{
    public class CursoGerenciador : BaseGerenciador
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
        public IQueryable<Curso> RecuperarCursos()
        {
            return _context.Curso.Select(c => new Curso
            {
                Id        = c.Id,
                Nome      = c.Nome,
                Descricao = c.Descricao,
                PathFoto  = c.PathFoto
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
