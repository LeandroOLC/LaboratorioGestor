using LaboratorioGestor.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioGestor.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Enderecos>
    {
        Task<Enderecos> ObterEnderecoPorDentista(Guid DentistaId);
        Task<Enderecos> ObterEnderecoPorProtetico(Guid ProteticoId);
        Task<Enderecos> ObterEnderecoPorLaboratorio(Guid LaboratorioId);
    }
}
