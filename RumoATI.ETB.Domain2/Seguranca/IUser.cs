using System.Collections.Generic;
using System.Security.Claims;

namespace RumoATI.ETB.Domain2.Seguranca
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
