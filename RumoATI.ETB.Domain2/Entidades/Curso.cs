using RumoATI.ETB.Domain2.Entidades;
using System.Collections.Generic;

namespace umoATI.ETB.Domain2.Entidades
{
    public class Curso : EntidadeBase
    {
        public Curso()
        {
            ProfessoresCurso = new List<ProfessorCurso>();
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<ProfessorCurso> ProfessoresCurso { get; set; }
    }
}