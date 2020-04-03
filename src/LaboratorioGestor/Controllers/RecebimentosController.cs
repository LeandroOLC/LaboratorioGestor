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
    public class RecebimentosController : BaseController
    {
        private readonly IRecebimentoRepository _recebimentosRepository;
        private readonly ICobrancaRepository _cobrancaRepository;
        private readonly IRecebimentoService _recebimentoService;
        private readonly IMapper _mapper;
        private static INotificador notificador;

        public RecebimentosController(IRecebimentoRepository recebimentoRepository,
                                      IMapper mapper,
                                      IUser user,
                                      IRecebimentoService recebimentoService,
                                      ICobrancaRepository cobrancaRepository)  : base(notificador, user)
        {
            _mapper = mapper;
            _recebimentosRepository = recebimentoRepository;
            _cobrancaRepository = cobrancaRepository;
            _recebimentoService = recebimentoService;
        }

        public async Task<IActionResult> Index(int? pagina, string IDPesquisa)
        {
            var _pesquisa = string.IsNullOrEmpty(IDPesquisa) ? Guid.Empty : Guid.Parse(IDPesquisa);

            return View(_mapper.Map<StaticPagedList<RecebimentosViewModel>>(await _recebimentosRepository.ObterRecebimentosPesquisaPaginado(pagina, _pesquisa)));
        }

        // GET: HaverContasAReceber/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var haverContasAReceberViewModel = _mapper.Map<IEnumerable<RecebimentosViewModel>>(await _recebimentosRepository.ObterPorId(id));
            if (haverContasAReceberViewModel == null)
            {
                return NotFound();
            }

            return View(haverContasAReceberViewModel);
        }

        // GET: HaverContasAReceber/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RecebimentosViewModel haverContasAReceberViewModel)
        {
            if (ModelState.IsValid)
            {
                var haverContasAReceber = _mapper.Map<Recebimentos>(haverContasAReceberViewModel);
                await _recebimentosRepository.Adicionar(haverContasAReceber);
                await _recebimentosRepository.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(haverContasAReceberViewModel);
        }


        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var haverContasAReceberViewModel = _mapper.Map<IEnumerable<RecebimentosViewModel>>(await _recebimentosRepository.ObterPorId(id));
            if (haverContasAReceberViewModel == null)
            {
                return NotFound();
            }
            return View(haverContasAReceberViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, RecebimentosViewModel haverContasAReceberViewModel)
        {
            if (id != haverContasAReceberViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var haverContasAReceber = _mapper.Map<Recebimentos>(haverContasAReceberViewModel);
                    await _recebimentosRepository.Atualizar(haverContasAReceber);
                    await _recebimentosRepository.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HaverContasAReceberViewModelExists(haverContasAReceberViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(haverContasAReceberViewModel);
        }

        // GET: HaverContasAReceber/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var haverContasAReceberViewModel = _mapper.Map<IEnumerable<RecebimentosViewModel>>(await _recebimentosRepository.ObterPorId(id));

            if (haverContasAReceberViewModel == null)
            {
                return NotFound();
            }

            return View(haverContasAReceberViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _recebimentosRepository.Remover(id);
            await _recebimentosRepository.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: HaverContasAReceber/Create
        public async Task<IActionResult> NovoRecebimento(Guid IDCobrancas)
        {
            var cobranca = await _cobrancaRepository.ObterPorId(IDCobrancas);

            if (cobranca == null) return NotFound();
            return PartialView("_NovoRecebimento", _mapper.Map<RecebimentosViewModel>(new Recebimentos { IDCobrancas = IDCobrancas, IDProtetico = ProteticoId }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NovoRecebimento(RecebimentosViewModel recebimentosViewModel)
        {
            var IDCobranca = Guid.Parse(recebimentosViewModel.IDCobrancas.ToString());
            var cobranca = await _cobrancaRepository.ObterPorId(IDCobranca);

            if (cobranca == null) return NotFound();

            if (!ModelState.IsValid) return View(recebimentosViewModel);

            var recebimentos = _mapper.Map<Recebimentos>(recebimentosViewModel);
            recebimentos.IDProtetico = ProteticoId;

            await _recebimentoService.Adicionar(recebimentos);

            if (!OperacaoValida()) return PartialView("_NovoRecebimento", recebimentosViewModel);

            var url = Url.Action("Index", "Cobrancas");

            return Json(new { success = true, url });
        }

        private bool HaverContasAReceberViewModelExists(Guid id)
        {
            return _recebimentosRepository.Buscar(e => e.Id == id).Result.Any();
        }

        private async Task<RecebimentosViewModel> ObterRecebimentos(Guid id)
        {
            return _mapper.Map<RecebimentosViewModel>(await _recebimentosRepository.ObterPorId(id));
        }

    }
}
