using LaboratorioGestor.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioGestor.Business.Interfaces
{
    public interface ICobrancaRepository : IRepository<Cobrancas>
    {
        Task<IEnumerable<Cobrancas>> ObterCobrancasRebimentos(Guid Id);

        Task RemoverCobranca(Cobrancas cobrancas);
    }
}
