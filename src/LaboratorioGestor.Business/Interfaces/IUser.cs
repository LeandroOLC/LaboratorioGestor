using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace LaboratorioGestor.Business.Interfaces
{
    public interface IUser 
    {
        string Name { get; }
        string UserId { get; }
        Guid GetUserId();
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
