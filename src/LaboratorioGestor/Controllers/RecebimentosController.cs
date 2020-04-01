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

namespace LaboratorioGestor.App.Controllers
{
    public class RecebimentosController : BaseController
    {
        private readonly IRecebimentoRepository _recebimentosRepository;
        private readonly IMapper _mapper;
        private static INotificador notificador;

        public RecebimentosController(IRecebimentoRepository recebimentoRepository,
                                             IMapper mapper,
                                               IUser user)  : base(notificador, user)
        {
            _mapper = mapper;
            _recebimentosRepository = recebimentoRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<RecebimentosViewModel>>(await _recebimentosRepository.ObterTodos()));
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

        private bool HaverContasAReceberViewModelExists(Guid id)
        {
            return _recebimentosRepository.Buscar(e => e.Id == id).Result.Any();
        }
    }
}
