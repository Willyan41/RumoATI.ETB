using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RumoATI.ETB.Web.Models
{
    public class ProfessorViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Campo Obrigatório")]
        public string Nome { get; set; }
        [Required]
        public string SobreNome { get; set; }
        [Required]
        public string Email { get; set; }

        public IQueryable<ProfessorViewModel> Professores { get; set; }
    }
}
