using LaboratorioGestor.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioGestor.Business.Interfaces
{
    public interface IServicoService : IDisposable
    {
        Task Adicionar(Servicos servicos);
        Task Atualizar(Servicos servicos);
        Task Remover(Guid id);
    }
}