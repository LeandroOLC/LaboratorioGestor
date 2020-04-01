using LaboratorioGestor.Business.Interfaces;
using LaboratorioGestor.Business.Models;
using LaboratorioGestor.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioGestor.Business.Services
{
    public class ServicoService : BaseService, IServicoService
    {

        public IServicoRepository _servicoRepository { get; set; }

        public ServicoService(IServicoRepository servicoRepository,
                              INotificador notificador) : base(notificador)
        {
            _servicoRepository = servicoRepository;
        }

        public async Task Adicionar(Servicos servicos)
        {
            if (!ExecutarValidacao(new ServicosValidation(), servicos)) return;

            servicos.DataCadastro = DateTime.Now;
            servicos.Produtos = null;
            servicos.Proteticos = null;
            servicos.Dentistas = null;
            servicos.IDCobranca = null;
            
            await _servicoRepository.Adicionar(servicos);
        }

        public async Task Atualizar(Servicos servicos)
        {
            if (!ExecutarValidacao(new ServicosValidation(), servicos)) return;

            servicos.Produtos = null;
            servicos.Proteticos = null;
            servicos.Dentistas = null;
            servicos.IDCobranca = null;

            await _servicoRepository.Atualizar(servicos);
        }

        public async Task Remover(Guid id)
        {
            await _servicoRepository.Remover(id);
        }

        public void Dispose()
        {
            _servicoRepository?.Dispose();
        }

    }
}
