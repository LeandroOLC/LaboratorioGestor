using LaboratorioGestor.Business.Interfaces;
using LaboratorioGestor.Business.Models;
using LaboratorioGestor.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioGestor.Data.Repository
{
    public class CobrancasRepository : Repository<Cobrancas>, ICobrancaRepository
    {
        public CobrancasRepository(MeuDbContext context) : base(context) { }

        public async Task<IEnumerable<Cobrancas>> ObterCobrancasRebimentos(Guid Id)
        {
            return await Db.Cobrancas.AsNoTracking().Include(f => f.Recebimentos)
              .Where(p => p.Id == Id).ToListAsync();
        }

        public async Task RemoverCobranca(Cobrancas cobrancas)
        {
            Db.Cobrancas.Remove(cobrancas);
            await SaveChanges();
        }

    }
}
