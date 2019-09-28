using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using umoATI.ETB.Domain2.Entidades;

namespace RumoATI.ETB.Web.Models
{
    public class ProfessorViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Campo Obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string SobreNome { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Email { get; set; }

        public IQueryable<Curso> Cursos { get; set; }
        public int[] CursoSelecionados { get; set; }
        public IQueryable<ProfessorViewModel> Professores { get; set; }
    }
}
