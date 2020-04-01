using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaboratorioGestor.App.ViewModels;
using LaboratorioGestor.Data;
using LaboratorioGestor.Business.Interfaces;
using AutoMapper;
using LaboratorioGestor.Business.Models;
using X.PagedList;

namespace LaboratorioGestor.App.Controllers
{
    public class ProdutosController : BaseController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoServico;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository produtoRepository,
                                  IProdutoService produtoServico,
                                  IMapper mapper,
                                  INotificador notificador, IUser user) : base(notificador, user)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _produtoServico = produtoServico;
        }

        // GET: Produtos
        public async Task<IActionResult> Index(int pagina = 1)
        {
            return View(_mapper.Map<StaticPagedList<ProdutoViewModel>>(await _produtoRepository.ObterTodosPaginado(pagina)));
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);
            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) return View(produtoViewModel);

            var produto = _mapper.Map<Produtos>(produtoViewModel);
            await _produtoServico.Adicionar(produto);

            if (!OperacaoValida()) return View(produtoViewModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var dentistaViewModel = await ObterProduto(id);
            if (dentistaViewModel == null)
            {
                return NotFound();
            }
            return View(dentistaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(produtoViewModel);

            var produtos = _mapper.Map<Produtos>(produtoViewModel);
            await _produtoServico.Atualizar(produtos);

            if (!OperacaoValida()) return View(await ObterProduto(id));

            return RedirectToAction("Index");
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);
            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produto = await ObterProduto(id);

            if (produto == null) return NotFound();

            await _produtoServico.Remover(id);

            if (!OperacaoValida()) return View(produto);

            return RedirectToAction("Index");
        }

        private bool ProdutoViewModelExists(Guid id)
        {
            return _produtoRepository.Buscar(e => e.Id == id).Result.Any();
        }
        private async Task<ProdutoViewModel> ObterProduto(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(id));
        }
    }
}
