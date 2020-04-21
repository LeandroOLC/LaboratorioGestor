using LaboratorioGestor.Business.Interfaces;
using LaboratorioGestor.Business.Models;
using LaboratorioGestor.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace LaboratorioGestor.Data.Repository
{
    public class RecebimentosrRepository : Repository<Recebimentos>, IRecebimentoRepository
    {
       
        public int _registroPorPagina { get; set; }

        public RecebimentosrRepository(MeuDbContext context, IConfiguration Config) : base(context) 
        {
             _registroPorPagina = Config.GetValue<int>("RegistrosPorPagina");
        }

        public async Task<IEnumerable<Recebimentos>> ObterRecebimentosCobrancas(Guid CobrancaId)
        {
            return await Buscar(p => p.IDCobranca == CobrancaId);
        }

        public async Task<IPagedList<Recebimentos>> ObterRecebimentosPesquisaPaginado(int? pagina, Guid? pesquisa)
        {
            var _pagina = pagina ?? 1;

            IEnumerable<Recebimentos> recebimentos;

            recebimentos = await Db.Recebimentos.AsNoTracking()
                           .Include(f => f.Cobrancas)
                           .Where(c => c.Cobrancas.IDDentista == pesquisa).ToListAsync();

            return await recebimentos.ToPagedListAsync(_pagina, _registroPorPagina);
        }
    }
}
