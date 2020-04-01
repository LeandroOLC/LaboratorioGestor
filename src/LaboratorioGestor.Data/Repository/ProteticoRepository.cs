using LaboratorioGestor.Business.Interfaces;
using LaboratorioGestor.Business.Models;
using LaboratorioGestor.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioGestor.Data.Repository
{
    public class ProteticoRepository : Repository<Proteticos>, IProteticoRepository
    {
        public ProteticoRepository(MeuDbContext context) : base(context) { }

        public async Task<Proteticos> ObterProteticoContato(Guid id)
        {
            return await Db.Proteticos.AsNoTracking().Include(f => f.Contatos)
               .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Proteticos> ObterProteticoEndereco(Guid id)
        {
            return await Db.Proteticos.AsNoTracking().Include(f => f.Enderecos)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
