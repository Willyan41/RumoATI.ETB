using RumoATI.ETB.Domain2.Context;
using RumoATI.ETB.Domain2.Seguranca;
using System.Linq;

namespace RumoATI.ETB.Domain2.Gerenciador
{
    public class UsuarioGerenciador : BaseGerenciador
    {
        public UsuarioGerenciador()
        {
            this._context = new ETBContext();
        }

        public bool AutorizarUsuario(Responsavel usuario)
        {
            return _context.Usuario.Any(u => u.Login == usuario.Login && u.Senha == usuario.Senha);
        }
    }
}
