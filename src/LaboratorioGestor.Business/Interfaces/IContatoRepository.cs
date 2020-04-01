using LaboratorioGestor.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioGestor.Business.Interfaces
{
    public interface IContatoRepository : IRepository<Contatos>
    {
        Task<Contatos> ObterContatoPorDentista(Guid DentistaId);
        Task<Contatos> ObterContatoPorProtetico(Guid ProteticoId);
        Task<Contatos> ObterContatoPorLaboratorio(Guid LaboratorioId);
    }
}
