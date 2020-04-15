using LaboratorioGestor.Business.Interfaces;
using LaboratorioGestor.Business.Models;
using LaboratorioGestor.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioGestor.Business.Services
{
    public class RecebimentosService : BaseService, IRecebimentoService
    {
        public IRecebimentoRepository _recebimentoRepository { get; set; }
        public ICobrancaRepository _cobrancaRepository { get; set; }

        public RecebimentosService(IRecebimentoRepository  recebimentoRepository,
                                   ICobrancaRepository cobrancaRepository,
                                   INotificador notificador) : base(notificador)
        {
            _recebimentoRepository = recebimentoRepository;
            _cobrancaRepository = cobrancaRepository;
        }

        public async Task Adicionar(Recebimentos recebimentos)
        {
            // 1 = debito ; 2 = credito ;  3 = valor restante da ficha anterior 
            recebimentos.TipoRecebimento = 1;
            recebimentos.DataCadastro = DateTime.Now;

            if (!ExecutarValidacao(new RecebimentosValidation(), recebimentos)) return;

            var cobranca = await _cobrancaRepository.ObterPorId(recebimentos.IDCobrancas);

            if(cobranca.ValorTotal == cobranca.ValorRecebimento)
            {
                Notificar("Cobrança selecionada já foi quitada.");
                return;
            }

            if (recebimentos.Valor > cobranca.ValorTotal)
            {
                Notificar("Valor recebido maior do que o titulo selecionado.");
                return;
            }

            if (recebimentos.Valor > cobranca.ValorRestante)
            {
                Notificar("Valor recebido maior do que restante para quitar o cobrança.");
                return;
            }

            await _recebimentoRepository.Adicionar(recebimentos);

            cobranca.ValorRecebimento += recebimentos.Valor;
            cobranca.ValorRestante -= recebimentos.Valor;

           await _cobrancaRepository.Atualizar(cobranca);
        }

        public Task Atualizar(Recebimentos recebimentos)
        {
            throw new NotImplementedException();
        }

        public async Task Remover(Guid id)
        {
            var recebimento = await _recebimentoRepository.ObterPorId(id);
            var cobranca = await _cobrancaRepository.ObterPorId(recebimento.IDCobrancas);

            await _recebimentoRepository.Remover(recebimento.Id);

            cobranca.ValorRecebimento -= recebimento.Valor;
            cobranca.ValorRestante += recebimento.Valor;

            await _cobrancaRepository.Atualizar(cobranca);
        }

        public void Dispose()
        {
            _cobrancaRepository?.Dispose();
            _recebimentoRepository?.Dispose();
        }
    }
}
