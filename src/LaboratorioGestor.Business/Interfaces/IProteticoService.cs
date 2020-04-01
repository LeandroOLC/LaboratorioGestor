using LaboratorioGestor.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioGestor.Business.Interfaces
{
    public interface IProteticoService : IDisposable
    {
        Task Adicionar(Proteticos proteticos);
        Task Atualizar(Proteticos proteticos);
        Task Remover(Guid id);
    }
}
