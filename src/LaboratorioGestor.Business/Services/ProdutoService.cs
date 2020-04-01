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
    public class ProdutoService : BaseService, IProdutoService
    {
        public IProdutoRepository _produtoRepository { get; set; }
       
        public ProdutoService(IProdutoRepository produtoRepository,
                              INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
        }
        public async Task Adicionar(Produtos produtos)
        {
            if (!ExecutarValidacao(new ProdutosValidation(), produtos)) return;

            if (_produtoRepository.Buscar(f => f.Nome.Trim().ToUpper() == produtos.Nome.Trim().ToUpper()).Result.Any())
            {
                Notificar("Já existe um produto cadastrado com esse nome.");
                return;
            }

            produtos.DataDoCadastro = DateTime.Now;

            await _produtoRepository.Adicionar(produtos);
        }

        public async Task Atualizar(Produtos produtos)
        {
            if (!ExecutarValidacao(new ProdutosValidation(), produtos)) return;

            if (_produtoRepository.Buscar(f => f.Nome == produtos.Nome).Result.Any())
            {
                Notificar("Já existe um produto cadastrado com esse nome informado.");
                return;
            }

            produtos.DataDoCadastro = DateTime.Now;

            await _produtoRepository.Atualizar(produtos);
        }
        public async Task Remover(Guid id)
        {
            await _produtoRepository.Remover(id);
        }
        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }
    }
}
