using RumoATI.ETB.Domain.Context;
using System;
using System.Linq;

namespace RumoATI.ETB.Domain.Gerenciador
{
    public class ProfessorGerenciador
    {
        BRINCANDO_SQLEntities context;
        public ProfessorGerenciador()
        {
            context = new BRINCANDO_SQLEntities();
        }

        public void Add(BS_002_PROFESSOR professor)
        {
            try
            {
                if (professor != null)
                {
                    context.BS_002_PROFESSOR.Add(professor);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
            }
        }

        public IQueryable<BS_002_PROFESSOR> GetAll()
        {
            return context.BS_002_PROFESSOR;
        }
    }
}
