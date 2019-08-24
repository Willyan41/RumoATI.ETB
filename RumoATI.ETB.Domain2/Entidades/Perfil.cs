using System.Collections.Generic;

namespace RumoATI.ETB.Domain2.Entidades
{
    public class Perfil : EntidadeBase
    {
        public Perfil()
        {
            Usuarios = new List<Usuario>();
        }
        public string Descricao { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}