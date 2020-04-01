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
    public class LaboratorioService : BaseService, ILaboratorioService
    {
        private readonly ILaboratorioRepository _laboratorioRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IContatoRepository _contatoRepository;
        public LaboratorioService(ILaboratorioRepository laboratorioRepository,
                                  IEnderecoRepository enderecoRepository,
                                  IContatoRepository contatoRepository,
                                  INotificador notificador) : base(notificador)
        {
            _contatoRepository = contatoRepository;
            _laboratorioRepository = laboratorioRepository; 
            _enderecoRepository = enderecoRepository;
        }
        public async Task Adicionar(Laboratorios laboratorios)
        {
            if (!ExecutarValidacao(new LaboratoriosValidation(), laboratorios)
              || !ExecutarValidacao(new EnderecosValidation(), laboratorios.Enderecos)
               || !ExecutarValidacao(new ContatosValidation(), laboratorios.Contatos)) return;

            if (_laboratorioRepository.Buscar(f => f.Documento == laboratorios.Documento).Result.Any())
            {
                Notificar("Já existe um Dentista com esse documento informado.");
                return;
            }

            laboratorios.Enderecos.TipoEndereco = 2;
            laboratorios.Enderecos.DataDoCadastro = DateTime.Now;
            laboratorios.Contatos.TipoContato = 2;
            laboratorios.Contatos.DataDoCadastro = DateTime.Now;
            laboratorios.DataDoCadastro = DateTime.Now;

            await _laboratorioRepository.Adicionar(laboratorios);
        }

        public async Task Atualizar(Laboratorios laboratorios)
        {
            if (!ExecutarValidacao(new LaboratoriosValidation(), laboratorios)
            || !ExecutarValidacao(new EnderecosValidation(), laboratorios.Enderecos)
             || !ExecutarValidacao(new ContatosValidation(), laboratorios.Contatos)) return;

            if (_laboratorioRepository.Buscar(f => f.Documento == laboratorios.Documento && f.Id != laboratorios.Id).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento infomado.");
                return;
            }

            laboratorios.Enderecos.TipoEndereco = 2;
            laboratorios.Enderecos.DataDoCadastro = DateTime.Now;
            laboratorios.Contatos.TipoContato = 2;
            laboratorios.Contatos.DataDoCadastro = DateTime.Now;
            laboratorios.DataDoCadastro = DateTime.Now;

            await _laboratorioRepository.Atualizar(laboratorios);
        }

        public void Dispose()
        {
            _contatoRepository?.Dispose();
            _laboratorioRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }

        public async Task Remover(Guid id)
        {
            var laboratorio = await _laboratorioRepository.ObterLaboratorioEnderecoContato(id);

            if (laboratorio == null)
                return;

            await _laboratorioRepository.Remover(id);
        }
    }
}
