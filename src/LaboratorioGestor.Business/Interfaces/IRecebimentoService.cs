using LaboratorioGestor.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioGestor.Business.Interfaces
{
    public interface IRecebimentoService : IDisposable
    {
        Task Adicionar(Recebimentos recebimentos);
        Task Atualizar(Recebimentos recebimentos);
        Task Remover(Guid id);
    }
}
