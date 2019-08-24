using System.Collections.Generic;
using umoATI.ETB.Domain2.Entidades;

namespace RumoATI.ETB.Domain2.Entidades
{
    public class Professor : EntidadeBase
    {
        public Professor()
        {
            ProfessoresCurso = new List<ProfessorCurso>();
        }

        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public Usuario Usuario { get; set; }
        public virtual IList<ProfessorCurso> ProfessoresCurso { get; set; }
    }
}
