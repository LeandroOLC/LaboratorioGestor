using AutoMapper;
using LaboratorioGestor.App.ViewModels;
using LaboratorioGestor.Business.Interfaces;
using LaboratorioGestor.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaboratorioGestor.App.Controllers
{
    public class DentistasController : BaseController
    {
        private readonly IDentistaRepository _dentistaRepository;
        private readonly IDentistaService _dentistaService;
        private readonly IMapper _mapper;
        private readonly IUser _user;

        public DentistasController(IDentistaRepository dentistaRepositry,
                                   IMapper mapper,
                                   IDentistaService dentistaService,
                                   INotificador notificador, IUser user) : base(notificador,user)
        {
            _mapper = mapper;
            _dentistaRepository = dentistaRepositry;
            _dentistaService = dentistaService;
            _user = user;
        }

        // GET: Dentistas
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<DentistaViewModel>>(await _dentistaRepository.ObterTodos()));
        }

        // GET: Dentistas/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var dentistaViewModel = await ObterDentistaEnderecoContato(id);
            if (dentistaViewModel == null)
            {
                return NotFound();
            }

            return View(dentistaViewModel);
        }

        // GET: Dentistas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DentistaViewModel dentistaViewModel)
        {
            if (!ModelState.IsValid) return View(dentistaViewModel);

            var dentista = _mapper.Map<Dentistas>(dentistaViewModel);
            await _dentistaService.Adicionar(dentista);

            if (!OperacaoValida()) return View(dentistaViewModel);
            return RedirectToAction(nameof(Index));

        }

        // GET: Dentistas/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var dentistaViewModel = await ObterDentistaEnderecoContato(id);
            if (dentistaViewModel == null)
            {
                return NotFound();
            }
            return View(dentistaViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, DentistaViewModel dentistaViewModel)
        {
            if (id != dentistaViewModel.Id)  return NotFound();
            
            if (!ModelState.IsValid) return View(dentistaViewModel);

            var dentista = _mapper.Map<Dentistas>(dentistaViewModel);
            await _dentistaService.Atualizar(dentista);

            if (!OperacaoValida()) return View(await ObterDentistaEnderecoContato(id));

            return RedirectToAction("Index");
        }

        // GET: Dentistas/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var dentistaViewModel = await ObterDentistaEnderecoContato(id);
            if (dentistaViewModel == null)
            {
                return NotFound();
            }

            return View(dentistaViewModel);
        }

        // POST: Dentistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var dentista = await ObterDentistaEnderecoContato(id);

            if (dentista == null) return NotFound();

            await _dentistaService.Remover(id);

            if (!OperacaoValida()) return View(dentista);

            return RedirectToAction("Index");
        }
        
        private bool DentistaViewModelExists(Guid id)
        {
            return _dentistaRepository.Buscar(c => c.Id == id).Result.Any();
        }

        private async Task<DentistaViewModel> ObterDentistaEnderecoContato(Guid id)
        {
            return _mapper.Map<DentistaViewModel>(await _dentistaRepository.ObterDentistaEnderecoContato(id));
        }
    }
}
