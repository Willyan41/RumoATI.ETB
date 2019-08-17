using RumoATI.ETB.Domain2.Context;
using RumoATI.ETB.Domain2.Entidades;
using System;
using System.Linq;

namespace RumoATI.ETB.Domain2.Gerenciador
{
    public class ProfessorGerenciador : GerenciadorBase
    {
        public ProfessorGerenciador()
        {
            _context = new ETBContext();
        }

        // TENTANDO FAZER O DELETE
        public void Delete(Professor professor)
        {
            try
            {
                if (professor != null)
                {
                    _context.Professors.Remove(professor);

                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //finalizando a tentativa

        public void Add(Professor professor)
        {
            try
            {
                if (professor != null)
                {
                    if (professor.Id == 0)
                        _context.Professors.Add(professor);
                    else
                        _context.Update(professor);

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
