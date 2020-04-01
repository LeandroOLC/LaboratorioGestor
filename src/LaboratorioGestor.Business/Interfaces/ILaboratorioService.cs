using LaboratorioGestor.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioGestor.Business.Interfaces
{
    public interface ILaboratorioService : IDisposable
    {
        Task Adicionar(Laboratorios laboratorios);
        Task Atualizar(Laboratorios laboratorios);
        Task Remover(Guid id);
    }
}
