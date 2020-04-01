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
    public class DentistaService : BaseService, IDentistaService
    {
        private readonly IDentistaRepository _dentistaRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IContatoRepository _contatoRepository;

        public DentistaService(IDentistaRepository dentistaRepository,
                               IContatoRepository contatoRepository,
                               IEnderecoRepository enderecoRepository,
                               INotificador notificador) : base(notificador)
        {
            _contatoRepository = contatoRepository;
            _dentistaRepository = dentistaRepository;
            _enderecoRepository = enderecoRepository;
        }


        public async Task Adicionar(Dentistas dentistas)
        {
            if (!ExecutarValidacao(new DentistasValidation(), dentistas)
                || !ExecutarValidacao(new EnderecosValidation(), dentistas.Enderecos)
                 || !ExecutarValidacao(new ContatosValidation(), dentistas.Contatos)) return;

            if (_dentistaRepository.Buscar(f => f.Documento == dentistas.Documento).Result.Any())
            {
                Notificar("Já existe um Dentista com esse documento informado.");
                return;
            }

            dentistas.Enderecos.TipoEndereco = 1;
            dentistas.Enderecos.DataDoCadastro = DateTime.Now;
            dentistas.Contatos.TipoContato = 1;
            dentistas.Contatos.DataDoCadastro = DateTime.Now;
            dentistas.DataDoCadastro = DateTime.Now;

            await _dentistaRepository.Adicionar(dentistas);
        }

        public async Task Atualizar(Dentistas dentistas)
        {
            if (!ExecutarValidacao(new DentistasValidation(), dentistas)) return;

            if (_dentistaRepository.Buscar(f => f.Documento == dentistas.Documento && f.Id != dentistas.Id).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento infomado.");
                return;
            }

            dentistas.Enderecos.TipoEndereco = 1;
            dentistas.Enderecos.DataDoCadastro = DateTime.Now;
            dentistas.Contatos.TipoContato = 1;
            dentistas.Contatos.DataDoCadastro = DateTime.Now;
            dentistas.DataDoCadastro = DateTime.Now;

            await _dentistaRepository.Atualizar(dentistas);
        }

        public async Task Remover(Guid id)
        {
            var dentista = await _dentistaRepository.ObterDentistaEnderecoContato(id);

            if (dentista == null)
                return;

            await _dentistaRepository.Remover(id);
        }

        public void Dispose()
        {
            _contatoRepository?.Dispose();
            _dentistaRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }
    }
}
