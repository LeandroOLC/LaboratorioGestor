using LaboratorioGestor.Business.Interfaces;
using LaboratorioGestor.Business.Models;
using LaboratorioGestor.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LaboratorioGestor.Data.Repository
{
    public class DentistaRepository : Repository<Dentistas>, IDentistaRepository
    {
        public DentistaRepository(MeuDbContext context) : base(context) { }

        public async Task<Dentistas> ObterDentistaEnderecoContato(Guid id)
        {
            return await Db.Dentistas.AsNoTracking()
                                     .Include(f => f.Contatos)
                                     .Include(f => f.Enderecos)
                                     .FirstOrDefaultAsync(p => p.Id == id );
        }
    }
}
