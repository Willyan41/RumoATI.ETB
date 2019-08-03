using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RumoATI.ETB.Web.Models
{
    public class CursoViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]

        public IQueryable<CursoViewModel> Curso { get; set; }
    }
}
