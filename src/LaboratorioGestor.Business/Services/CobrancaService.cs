using LaboratorioGestor.Business.Interfaces;
using LaboratorioGestor.Business.Models;
using LaboratorioGestor.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioGestor.Business.Services
{
    public class CobrancaService : BaseService, ICobrancaService
    {
        public IServicoRepository _servicoRepository { get; set; }
        public ICobrancaRepository _cobrancaRepository { get; set; }

        public CobrancaService(IServicoRepository servicoRepository,
                               ICobrancaRepository cobrancaRepository,
                               INotificador notificador) : base(notificador)
        {
            _servicoRepository = servicoRepository;
            _cobrancaRepository = cobrancaRepository;
        }

        public async Task Adicionar(IEnumerable<Servicos> servicos)
        {
            if (servicos.Count() <= 0)
            {
                Notificar("Não foi possível efetuar a cobrança. " +
                          "Verifique se foi selecionado qual destista séra cobrado ou se mesmo foi lançado alguma serviço.");
                return;
            }

            var cobranca = new Cobrancas
            {
                IDDentista = servicos.FirstOrDefault().IDDentista,
                DataCadastro = DateTime.Now,
                ValorAcrecimo = 0,
                ValorDesconto = 0,
                ValorRecebimento = 0,
                ValorRestante = servicos.Sum(c => c.Valor),
                ValorTotal = servicos.Sum(c => c.Valor),
            };

            if (!ExecutarValidacao(new CobrancasValidation(), cobranca)) return;

            await _cobrancaRepository.Adicionar(cobranca);

            foreach (var servico in servicos)
            {
                servico.IDCobranca = cobranca.Id;
                await _servicoRepository.Atualizar(servico);
            }
        }

        public async Task Atualizar(IEnumerable<Servicos> servicos)
        {
            if (servicos.Count() <= 0)
            {
                Notificar("Não foi possível efetuar a cobrança. " +
                          "Verifique se foi selecionado qual destista séra cobrado ou se mesmo foi lançado alguma serviço.");
                return;
            }

            Guid IdCobranca = Guid.Parse(servicos.FirstOrDefault().IDCobranca.ToString());
            var cobranca = new Cobrancas
            {
                Id = IdCobranca,
                IDDentista = servicos.FirstOrDefault().IDDentista,
                DataCadastro = DateTime.Now,
                ValorAcrecimo = 0,
                ValorDesconto = 0,
                ValorRecebimento = 0,
                ValorRestante = servicos.Sum(c => c.Valor),
                ValorTotal = servicos.Sum(c => c.Valor),
            };

            if (!ExecutarValidacao(new CobrancasValidation(), cobranca)) return;

            await _cobrancaRepository.Atualizar(cobranca);

            var _NovosServicosAdicionados = servicos.Where(c => c.IDCobranca == Guid.Empty || c.IDCobranca == null).ToList();

            foreach (var servico in _NovosServicosAdicionados)
            {
                servico.IDCobranca = cobranca.Id;
                await _servicoRepository.Atualizar(servico);
            }
        }

        public async Task Remover(Guid id)
        {
            await _servicoRepository.RemoverServicoPorCobranca(id); 
            
            await _cobrancaRepository.RemoverCobranca( await _cobrancaRepository.ObterPorId(id));
        }

        public void Dispose()
        {
            _cobrancaRepository?.Dispose();
            _servicoRepository?.Dispose();
        }
    }
}
