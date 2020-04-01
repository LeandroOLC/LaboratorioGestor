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
    public class EnderecoRepository : Repository<Enderecos>, IEnderecoRepository
    {
        public EnderecoRepository(MeuDbContext context) : base(context) { }

        public async Task<Enderecos> ObterEnderecoPorDentista(Guid DentistaId)
        {
            return await Db.Enderecos.AsNoTracking().
                FirstOrDefaultAsync(d => d.DentistaId == DentistaId);
        }

        public async Task<Enderecos> ObterEnderecoPorLaboratorio(Guid LaboratorioId)
        {
            return await Db.Enderecos.AsNoTracking().
                 FirstOrDefaultAsync(d => d.LaboratorioId == LaboratorioId);
        }

        public async Task<Enderecos> ObterEnderecoPorProtetico(Guid ProteticoId)
        {
            return await Db.Enderecos.AsNoTracking().
                  FirstOrDefaultAsync(d => d.ProteticoId == ProteticoId);
        }
    }
}
