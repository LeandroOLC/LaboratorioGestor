using LaboratorioGestor.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioGestor.Business.Interfaces
{
    public interface IDentistaService : IDisposable
    {
        Task Adicionar(Dentistas dentistas);
        Task Atualizar(Dentistas dentistas);
        Task Remover(Guid id);
    }
}
