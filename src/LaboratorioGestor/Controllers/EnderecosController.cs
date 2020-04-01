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
    public class EnderecosController : Controller
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;

        public EnderecosController(IEnderecoRepository enderecoRepository,
                                   IMapper mapper)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
        }

        // GET: Enderecos
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<EnderecoViewModel>>(await _enderecoRepository.ObterTodos()));
        }

        // GET: Enderecos/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enderecoViewModel = _mapper.Map<IEnumerable<EnderecoViewModel>>(await _enderecoRepository.ObterPorId(id));
                
            if (enderecoViewModel == null)
            {
                return NotFound();
            }

            return View(enderecoViewModel);
        }

        // GET: Enderecos/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EnderecoViewModel enderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                var endereco = _mapper.Map<Enderecos>(enderecoViewModel);
                await _enderecoRepository.Adicionar(endereco);
                await _enderecoRepository.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(enderecoViewModel);
        }

        // GET: Enderecos/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enderecoViewModel = _mapper.Map<IEnumerable<EnderecoViewModel>>(await _enderecoRepository.ObterPorId(id));
            if (enderecoViewModel == null)
            {
                return NotFound();
            }
            return View(enderecoViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EnderecoViewModel enderecoViewModel)
        {
            if (id != enderecoViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var endereco = _mapper.Map<Enderecos>(enderecoViewModel);
                    await _enderecoRepository.Atualizar(endereco);
                    await _enderecoRepository.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnderecoViewModelExists(enderecoViewModel.Id))
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
            return View(enderecoViewModel);
        }

        // GET: Enderecos/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enderecoViewModel = _mapper.Map<IEnumerable<EnderecoViewModel>>(await _enderecoRepository.ObterPorId(id));
            if (enderecoViewModel == null)
            {
                return NotFound();
            }

            return View(enderecoViewModel);
        }

        // POST: Enderecos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _enderecoRepository.Remover(id);
            await _enderecoRepository.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool EnderecoViewModelExists(Guid id)
        {
            return _enderecoRepository.Buscar(c => c.Id == id).Result.Any();
        }
    }
}
