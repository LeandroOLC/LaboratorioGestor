using LaboratorioGestor.Business.Interfaces;
using LaboratorioGestor.Business.Models;
using LaboratorioGestor.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace LaboratorioGestor.Business.Services
{
    public class ProteticoService : BaseService, IProteticoService
    {
        public IProteticoRepository _proteticoRepository { get; set; }

        public ProteticoService(IProteticoRepository proteticoRepository,
                               INotificador notificador) : base(notificador)
        {
            _proteticoRepository = proteticoRepository;
        }

        public async Task Adicionar(Proteticos proteticos)
        {
            if (!ExecutarValidacao(new ProteticosValidation(), proteticos)) return;

            if (_proteticoRepository.Buscar(c => c.Nome == proteticos.Nome).Result.Any())
            {
                Notificar("Já existe um protético cadastrado com esse nome.");
                return;
            }
            
            proteticos.DataDoCadastro = DateTime.Now;
            proteticos.Enderecos.DataDoCadastro = DateTime.Now;
            proteticos.Contatos.DataDoCadastro = DateTime.Now;

            await _proteticoRepository.Adicionar(proteticos);
        }

        public async Task Atualizar(Proteticos proteticos)
        {
            if (!ExecutarValidacao(new ProteticosValidation(), proteticos)) return;

            if (_proteticoRepository.Buscar(c => c.Nome == proteticos.Nome).Result.Any())
            {
                Notificar("Já existe um protético cadastrado com esse nome.");
                return;
            }

            proteticos.DataDoCadastro = DateTime.Now;
            proteticos.Enderecos.DataDoCadastro = DateTime.Now;
            proteticos.Contatos.DataDoCadastro = DateTime.Now;

            await _proteticoRepository.Atualizar(proteticos);
        }

        public async Task Remover(Guid id)
        {
            await _proteticoRepository.Remover(id);
        }

        public void Dispose()
        {
            _proteticoRepository?.Dispose();
        }
    }
}
