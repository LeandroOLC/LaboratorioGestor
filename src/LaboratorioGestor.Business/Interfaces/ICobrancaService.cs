using LaboratorioGestor.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioGestor.Business.Interfaces
{
    public interface ICobrancaService : IDisposable
    {
        Task Adicionar(IEnumerable<Servicos> servicos);
        Task Atualizar(IEnumerable<Servicos> servicos);
        Task Remover(Guid id);
    }
}
