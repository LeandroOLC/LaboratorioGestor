using LaboratorioGestor.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioGestor.Business.Interfaces
{
    public interface IProteticoRepository : IRepository<Proteticos>
    {
        Task<Proteticos> ObterProteticoEndereco(Guid id);
        Task<Proteticos> ObterProteticoContato(Guid id);
    }
}
