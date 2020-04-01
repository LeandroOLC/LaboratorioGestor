using LaboratorioGestor.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace LaboratorioGestor.Business.Interfaces
{
    public interface IServicoRepository : IRepository<Servicos>
    {
        Task<IEnumerable<Servicos>> ObterServicosDentista(Guid DentistaId, bool somenteNaoCobrados = false);

        Task<IPagedList<Servicos>> ObterServicoPesquisaPaginado(int? pagina, Guid? pesquisa, bool somenteNaoCobrados = false);

        Task RemoverServicoPorCobranca(Guid CobrancaId);

        Task<IPagedList<Servicos>> ObterServicoPesquisaJaCobradoPaginado(int? pagina, Guid? pesquisa);

        Task<IEnumerable<Servicos>> ObterServicoPesquisaJaCobrado(Guid? pesquisa);
    }
}
