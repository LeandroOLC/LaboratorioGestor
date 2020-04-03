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

            await _recebimentoRepository.Adicionar(recebimentos);

            var cobrancaAtualizada = new Cobrancas
            {
                Id = cobranca.Id,
                IDDentista = cobranca.IDDentista,
                DataCadastro = cobranca.DataCadastro,
                ValorAcrecimo = 0,
                ValorDesconto = 0,
                ValorRecebimento = 0,
                ValorRestante = cobranca.ValorRestante - recebimentos.Valor,
                ValorTotal = cobranca.ValorTotal,
            };

            cobrancaAtualizada.Recebimentos.Add(recebimentos);
            await _cobrancaRepository.Atualizar(cobrancaAtualizada);
        }

        public Task Atualizar(Recebimentos recebimentos)
        {
            throw new NotImplementedException();
        }

        public async Task Remover(Guid id)
        {
            var recebimento = await _recebimentoRepository.ObterPorId(id);
            var cobranca = await _cobrancaRepository.ObterPorId(id);

            await _recebimentoRepository.Remover(id);

            var cobrancaAtualizada = new Cobrancas
            {
                Id = cobranca.Id,
                IDDentista = cobranca.IDDentista,
                DataCadastro = DateTime.Now,
                ValorAcrecimo = 0,
                ValorDesconto = 0,
                ValorRecebimento = 0,
                ValorRestante = cobranca.ValorRestante - recebimento.Valor,
                ValorTotal = cobranca.ValorTotal,
            };

            await _cobrancaRepository.Atualizar(cobrancaAtualizada);
        }

        public void Dispose()
        {
            _cobrancaRepository?.Dispose();
            _recebimentoRepository?.Dispose();
        }
    }
}
