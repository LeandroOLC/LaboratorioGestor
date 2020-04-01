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

namespace LaboratorioGestor.App.Controllers
{
    public class ContatosController : Controller
    {
        private readonly IContatoRepository _contatosRepository;
        private readonly IMapper _mapper;

        public ContatosController(IContatoRepository contatoRepository,
                                  IMapper mapper)
        {
            _contatosRepository = contatoRepository;
            _mapper = mapper;
        }

        // GET: Contatos
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ContatoViewModel>>(await _contatosRepository.ObterTodos()));
        }

        // GET: Contatos/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var contatoViewModel = (_mapper.Map<IEnumerable<ContatoViewModel>>(await _contatosRepository.ObterPorId(id)));
             
            if (contatoViewModel == null)
            {
                return NotFound();
            }

            return View(contatoViewModel);
        }

        // GET: Contatos/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( ContatoViewModel contatoViewModel)
        {
            if (ModelState.IsValid)
            {
                var contato = _mapper.Map<Contatos>(contatoViewModel);
                await _contatosRepository.Adicionar(contato);
                await _contatosRepository.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(contatoViewModel);
        }

        // GET: Contatos/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contatoViewModel = _mapper.Map<Contatos>(await _contatosRepository.ObterPorId(id));

            if (contatoViewModel == null)
            {
                return NotFound();
            }
            return View(contatoViewModel);
        }

        // POST: Contatos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ContatoViewModel contatoViewModel)
        {
            if (id != contatoViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var contasAReceber = _mapper.Map<Contatos>(contatoViewModel);
                    await _contatosRepository.Atualizar(contasAReceber);
                    await _contatosRepository.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContatoViewModelExists(contatoViewModel.Id))
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
            return View(contatoViewModel);
        }

        // GET: Contatos/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contatoViewModel = _mapper.Map<ContatoViewModel>(await _contatosRepository.ObterPorId(id));
            if (contatoViewModel == null)
            {
                return NotFound();
            }

            return View(contatoViewModel);
        }

        // POST: Contatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var contatosViewModel = await _contatosRepository.ObterPorId(id);

            if (contatosViewModel == null) return NotFound();

            await _contatosRepository.Remover(id);
            await _contatosRepository.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ContatoViewModelExists(Guid id)
        {
            return _contatosRepository.Buscar(e => e.Id == id).Result.Any();
        }
    }
}
