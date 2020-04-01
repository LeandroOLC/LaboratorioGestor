using AutoMapper;
using LaboratorioGestor.App.ViewModels;
using LaboratorioGestor.Business.Interfaces;
using LaboratorioGestor.Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace LaboratorioGestor.App.Controllers
{
    public class CobrancasController : BaseController
    {
        private readonly ICobrancaRepository _cobrancaRepository;
        private readonly IServicoRepository _servicoRepository;
        private readonly ICobrancaService _cobrancaService;
        private readonly IMapper _mapper;

        public CobrancasController(ICobrancaRepository cobrancaRepository,
                                   IServicoRepository servicoRepository,
                                   ICobrancaService cobrancaService,
                                   IMapper mapper,
                                   INotificador notificador, IUser user) : base(notificador, user)
        {
            _cobrancaRepository = cobrancaRepository;
            _servicoRepository = servicoRepository;
            _cobrancaService = cobrancaService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<CobrancaViewModel>>(await _cobrancaRepository.ObterTodos()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var contasAReceberViewModel = await ObterCobrancasRebimentos(id);

            if (contasAReceberViewModel == null)
            {
                return NotFound();
            }

            return View(contasAReceberViewModel);
        }

        public async Task<IActionResult> Create(int? pagina, Guid IDPesquisa)
        {
            var _servicos = await _servicoRepository.ObterServicoPesquisaPaginado(pagina, IDPesquisa, true);

            if (_servicos.Count <= 0)
                return View();

            var _servicosPaginado = _mapper.Map<StaticPagedList<ServicoViewModel>>(_servicos);

            return View(_servicosPaginado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guid IDPesquisa)
        {
            var _servicos = await _servicoRepository.ObterServicosDentista(IDPesquisa, true);

            var _servicoViewModel = _mapper.Map<IEnumerable<ServicoViewModel>>(_servicos);

            if (IDPesquisa == Guid.Empty)
                return View(_servicoViewModel.ToPagedList());

            await _cobrancaService.Adicionar(_servicos);

            if (!OperacaoValida()) return View(_servicoViewModel);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Edit(Guid id, int? pagina)
        {
            var cobrancaViewModel = await ObterCobrancas(id);

            if (cobrancaViewModel == null)
                return NotFound();

            var _servicos = await _servicoRepository.ObterServicoPesquisaJaCobradoPaginado(pagina, id);

            var _servicosPaginado = _mapper.Map<StaticPagedList<ServicoViewModel>>(_servicos);

            return View(_servicosPaginado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CobrancaViewModel contasAReceberViewModel)
        {
            if (id != contasAReceberViewModel.Id) return NotFound();

            var _servicos = await _servicoRepository.ObterServicoPesquisaJaCobrado(id); 
            await _cobrancaService.Atualizar(_servicos);

            if (!OperacaoValida()) return View(_servicos.ToPagedList());

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var cobrancasViewModel = await ObterCobrancas(id);
            if (cobrancasViewModel == null) return NotFound();

            return View(cobrancasViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var cobrancaViewModel = await ObterCobrancas(id);

            if (cobrancaViewModel == null) return NotFound();

            await _cobrancaService.Remover(id);

            if (!OperacaoValida()) return View(cobrancaViewModel);

            return RedirectToAction("Index");
        }

        private bool ContasAReceberViewModelExists(Guid id)
        {
            return _cobrancaRepository.Buscar(e => e.Id == id).Result.Any();
        }

        private async Task<IEnumerable<Servicos>> ObterServicosPorCobranca(Guid id)
        {
            return await _servicoRepository.Buscar(c => c.IDCobranca == id);
        }

        private async Task<CobrancaViewModel> ObterCobrancas(Guid id)
        {
            return _mapper.Map<CobrancaViewModel>(await _cobrancaRepository.ObterPorId(id));
        }

        private async Task<CobrancaViewModel> ObterCobrancasRebimentos(Guid id)
        {
            return _mapper.Map<CobrancaViewModel>(await _cobrancaRepository.ObterCobrancasRebimentos(id));
        }
    }
}
