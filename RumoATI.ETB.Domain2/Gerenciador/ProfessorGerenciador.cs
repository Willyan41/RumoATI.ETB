using RumoATI.ETB.Domain2.Context;
using RumoATI.ETB.Domain2.Entidades;
using System;
using System.Linq;

namespace RumoATI.ETB.Domain2.Gerenciador
{
    public class ProfessorGerenciador
    {
        ETBContext _context;
        public ProfessorGerenciador()
        {
            _context = new ETBContext();
        }

        public void Add(Professor professor)
        {
            try
            {
                if (professor != null)
                {
                    if(professor.Id == 0)
                        _context.Professors.Add(professor);

                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Professor RecuperarPorId(int id)
        {
            return _context.Professors.Find(id);
        }

        public IQueryable<Professor> RecuperarProfessores()
        {
            return _context.Professors.Select(p => new Professor
            {
                Id        = p.Id,
                Email     = p.Email,
                Nome      = p.Nome,
                SobreNome = p.SobreNome
            });
        }
    }
}
