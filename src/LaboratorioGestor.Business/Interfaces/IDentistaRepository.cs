using LaboratorioGestor.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioGestor.Business.Interfaces
{
    public interface IDentistaRepository : IRepository<Dentistas>
    {
        Task<Dentistas> ObterDentistaEnderecoContato(Guid id);
    }
}
