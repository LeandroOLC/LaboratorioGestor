using AutoMapper;
using LaboratorioGestor.App.ViewModels;
using LaboratorioGestor.Business.Interfaces;
using LaboratorioGestor.Business.Models;
using LaboratorioGestor.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaboratorioGestor.App.Controllers
{
    [Authorize]
    public class LaboratoriosController : BaseController
    {
        private readonly ILaboratorioRepository _laboratorioRepository;
        private readonly ILaboratorioService _laboratorioServico;
        private readonly IMapper _mapper;

        public LaboratoriosController(ILaboratorioRepository laboratorioRepository,
                                      IMapper mapper,
                                      ILaboratorioService laboratorioServico,
                                      INotificador notificador, IUser user) : base(notificador, user)
        {
            _laboratorioRepository = laboratorioRepository;
            _mapper = mapper;
            _laboratorioServico = laboratorioServico;
        }

        public async Task<IActionResult> Index(string nomePesquisar)
        {
            return View(_mapper.Map<IEnumerable<LaboratorioViewModel>>(await _laboratorioRepository.ObterTodos()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var laboratorioViewModel = await ObterLaboratorioEnderecoContato(id);
             
            if (laboratorioViewModel == null) return NotFound();
         
            return View(laboratorioViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LaboratorioViewModel laboratorioViewModel)
        {
            if (!ModelState.IsValid) return View(laboratorioViewModel);

            var laboratorios = _mapper.Map<Laboratorios>(laboratorioViewModel);
            await _laboratorioServico.Adicionar(laboratorios);

            if (!OperacaoValida()) return View(laboratorioViewModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var laboratorioViewModel = await ObterLaboratorioEnderecoContato(id);

            if (laboratorioViewModel == null)  return NotFound();
            
            return View(laboratorioViewModel);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, LaboratorioViewModel laboratorioViewModel)
        {
            if (id != laboratorioViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(laboratorioViewModel);

            var laboratorios = _mapper.Map<Laboratorios>(laboratorioViewModel);
            await _laboratorioServico.Atualizar(laboratorios);

            if (!OperacaoValida()) return View(await ObterLaboratorioEnderecoContato(id));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var laboratorioViewModel = await ObterLaboratorioEnderecoContato(id);
          
            if (laboratorioViewModel == null)  return NotFound();
            
            return View(laboratorioViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var laboratorio = await ObterLaboratorioEnderecoContato(id);

            if (laboratorio == null) return NotFound();

            await _laboratorioServico.Remover(id);

            if (!OperacaoValida()) return View(laboratorio);

            return RedirectToAction("Index");
        }

        private bool LaboratorioViewModelExists(Guid id)
        {
            return _laboratorioRepository.Buscar(e => e.Id == id).Result.Any();
        }
        private async Task<LaboratorioViewModel> ObterLaboratorioEnderecoContato(Guid id)
        {
            return _mapper.Map<LaboratorioViewModel>(await _laboratorioRepository.ObterLaboratorioEnderecoContato(id));
        }
    }
}
