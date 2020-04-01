using LaboratorioGestor.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioGestor.Business.Interfaces
{
    public interface IProdutoService : IDisposable
    {
        Task Adicionar(Produtos produtos);
        Task Atualizar(Produtos produtos);
        Task Remover(Guid id);
    }
}
