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
    public class ContatoRepository : Repository<Contatos>, IContatoRepository
    {
        public ContatoRepository(MeuDbContext context) : base(context) { }

        public async Task<Contatos> ObterContatoPorDentista(Guid DentistaId)
        {
            return await Db.Contatos.AsNoTracking().
               FirstOrDefaultAsync(d => d.DentistaId == DentistaId);
        }

        public async Task<Contatos> ObterContatoPorLaboratorio(Guid LaboratorioId)
        {
            return await Db.Contatos.AsNoTracking().
              FirstOrDefaultAsync(d => d.DentistaId == LaboratorioId);
        }

        public async Task<Contatos> ObterContatoPorProtetico(Guid ProteticoId)
        {
            return await Db.Contatos.AsNoTracking().
              FirstOrDefaultAsync(d => d.DentistaId == ProteticoId);
        }

    }
}
