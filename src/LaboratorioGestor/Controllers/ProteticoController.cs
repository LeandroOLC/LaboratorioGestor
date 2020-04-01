using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaboratorioGestor.App.ViewModels;
using LaboratorioGestor.Data;
using AutoMapper;
using LaboratorioGestor.Business.Interfaces;
using LaboratorioGestor.Business.Models;

namespace LaboratorioGestor.App.Controllers
{
    public class ProteticoController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IUser _user;
        private readonly IProteticoRepository _proteticoRepository;
        private readonly IProteticoService _proteticoService;

        public ProteticoController(IProteticoRepository proteticoRepository,
                                   IMapper mapper,
                                   INotificador notificador,
                                   IProteticoService proteticoService,
                                   IUser user) : base(notificador, user)
        {
            _proteticoRepository = proteticoRepository;
            _proteticoService = proteticoService;
            _mapper = mapper;
            _user = user;
        }

        // GET: Protetico
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProteticoViewModel>>(await _proteticoRepository.ObterTodos()));
        }

        // GET: Protetico/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var servicoViewModel = await ObterProtetico(id);
            if (servicoViewModel == null)
            {
                return NotFound();
            }

            return View(servicoViewModel);
        }

        // GET: Protetico/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Protetico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProteticoViewModel proteticoViewModel)
        {
            if (!ModelState.IsValid) return View(proteticoViewModel);

            var protetico = _mapper.Map<Proteticos>(proteticoViewModel);
            await _proteticoService.Adicionar(protetico);

            if (!OperacaoValida()) return View(proteticoViewModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: Protetico/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var proteticoViewModel = await ObterProtetico(id);
            if (proteticoViewModel == null)
            {
                return NotFound();
            }
            return View(proteticoViewModel);
        }

        // POST: Protetico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProteticoViewModel proteticoViewModel)
        {
            if (id != proteticoViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(proteticoViewModel);

            var proteticos = _mapper.Map<Proteticos>(proteticoViewModel);
            await _proteticoService.Atualizar(proteticos);

            if (!OperacaoValida()) return View(await ObterProtetico(id));

            return RedirectToAction("Index");
        }

        // GET: Protetico/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var servicoViewModel = await ObterProtetico(id);
            if (servicoViewModel == null)
            {
                return NotFound();
            }

            return View(servicoViewModel);
        }

        // POST: Protetico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var servico = await ObterProtetico(id);

            if (servico == null) return NotFound();

            await _proteticoService.Remover(id);

            if (!OperacaoValida()) return View(servico);

            return RedirectToAction("Index");
        }

        private bool ProteticoViewModelExists(Guid id)
        {
            return _proteticoRepository.Buscar(e => e.Id == id).Result.Any();
        }

        private async Task<ServicoViewModel> ObterProtetico(Guid id)
        {
            return _mapper.Map<ServicoViewModel>(await _proteticoRepository.ObterPorId(id));
        }
    }
}
