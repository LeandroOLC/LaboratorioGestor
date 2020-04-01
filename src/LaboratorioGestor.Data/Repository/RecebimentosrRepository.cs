using LaboratorioGestor.Business.Interfaces;
using LaboratorioGestor.Business.Models;
using LaboratorioGestor.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioGestor.Data.Repository
{
    public class RecebimentosrRepository : Repository<Recebimentos>, IRecebimentoRepository
    {
        public RecebimentosrRepository(MeuDbContext context) : base(context) { }

        public async Task<IEnumerable<Recebimentos>> ObterRecebimentosCobrancas(Guid CobrancaId)
        {
            return await Buscar(p => p.IDCobrancas == CobrancaId);
        }
    }
}
