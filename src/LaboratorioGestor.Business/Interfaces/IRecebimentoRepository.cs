using LaboratorioGestor.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace LaboratorioGestor.Business.Interfaces
{
    public interface IRecebimentoRepository : IRepository<Recebimentos>
    {
        Task<IEnumerable<Recebimentos>> ObterRecebimentosCobrancas(Guid CobrancaId);
        Task<IPagedList<Recebimentos>> ObterRecebimentosPesquisaPaginado(int? pagina, Guid? pesquisa);
    }
}
