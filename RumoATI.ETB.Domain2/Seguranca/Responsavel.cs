using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;

namespace RumoATI.ETB.Domain2.Seguranca
{
    public class Responsavel : IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public Responsavel(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public Responsavel(string login, string senha)
        {
            this.Login = login;
            this.Senha = senha;
        }

        public int ID { get; set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }

        public string Name => throw new System.NotImplementedException();

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
