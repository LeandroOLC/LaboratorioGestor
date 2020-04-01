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
    public class LaboratorioRepository : Repository<Laboratorios>, ILaboratorioRepository
    {
        public LaboratorioRepository(MeuDbContext context) : base(context) { }

        public async Task<Laboratorios> ObterLaboratorioEnderecoContato(Guid id)
        {
            return await Db.Laboratorios.AsNoTracking()
                .Include(f => f.Contatos)
                .Include(f => f.Enderecos)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
