
using LaboratorioGestor.Business.Interfaces;
using LaboratorioGestor.Business.Models;
using LaboratorioGestor.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace LaboratorioGestor.Data.Repository
{
    public class ServicoRepository : Repository<Servicos>, IServicoRepository
    {
        public ServicoRepository(MeuDbContext context) : base(context) { }

        public async Task<IPagedList<Servicos>> ObterServicoPesquisaPaginado(int? pagina, Guid? pesquisa, bool somenteNaoCobrados = false)
        {
            var _pagina = pagina ?? 1;

            IEnumerable<Servicos> servicos;

            if (somenteNaoCobrados)
                servicos = await Buscar(p => p.IDDentista == pesquisa && (p.IDCobranca == Guid.Empty || p.IDCobranca == null));
            else
                servicos = await Buscar(p => p.IDDentista == pesquisa || p.IDProtetico == pesquisa);

            return await servicos.ToPagedListAsync(_pagina, 3);
        }

        public async Task<IEnumerable<Servicos>> ObterServicosDentista(Guid DentistaId, bool somenteNaoCobrados = false)
        {
            if (DentistaId == null)
                return new List<Servicos>();

            IEnumerable<Servicos> servicos;

            if (somenteNaoCobrados)
                servicos = await Buscar(p => p.IDDentista == DentistaId && (p.IDCobranca == Guid.Empty || p.IDCobranca == null));
            else
                servicos = await Buscar(p => p.IDDentista == DentistaId);

            return servicos;
        }

        public async Task RemoverServicoPorCobranca(Guid CobrancaId)
        {
            var servicos = await Buscar(p => p.IDCobranca == CobrancaId);

            foreach (var servico in servicos)
            {
                servico.IDCobranca = null;
                Atualizar(servico);
            }
        }

        public async Task<IPagedList<Servicos>> ObterServicoPesquisaJaCobradoPaginado(int? pagina, Guid? pesquisa)
        {
            var _pagina = pagina ?? 1;

            IEnumerable<Servicos> servicos;

            servicos = await Buscar(p => p.IDCobranca == pesquisa || p.IDCobranca == Guid.Empty || p.IDCobranca == null);
         
            return await servicos.ToPagedListAsync(_pagina, 3);
        }

        public async Task<IEnumerable<Servicos>> ObterServicoPesquisaJaCobrado(Guid? pesquisa)
        {
            return  await Buscar(p => p.IDCobranca == pesquisa || p.IDCobranca == Guid.Empty || p.IDCobranca == null);
        }
    }
}
