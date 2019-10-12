using System;
using System.Collections.Generic;
using System.Text;
using RumoATI.ETB.Domain2.Entidades;

namespace RumoATI.ETB.Domain2.Entidades
{
    public class ProfessorCurso
    {
        public int IdProfessor { get; set; }
        public Professor Professor { get; set; }

        public int IdCurso { get; set; }
        public Curso Curso { get; set; }
    }
}
