using System.ComponentModel.DataAnnotations;

namespace RumoATI.ETB.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public string Messagem { get; set; }
    }
}
