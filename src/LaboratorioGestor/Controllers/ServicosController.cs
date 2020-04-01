using AutoMapper;
using LaboratorioGestor.App.ViewModels;
using LaboratorioGestor.Business.Interfaces;
using LaboratorioGestor.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace LaboratorioGestor.App.Controllers
{
    public class ServicosController : BaseController
    {
        private readonly IServicoRepository _servicoRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IDentistaRepository _dentistaRepository;
        private readonly IProteticoRepository _proteticoRepository;
        private readonly IServicoService _servicoService;
        private readonly IMapper _mapper;

        public ServicosController(IServicoRepository servicoRepository,
                                  IServicoService servicoService,
                                  IDentistaRepository dentistaRepository,
                                  IProdutoRepository produtoRepository,
                                  IProteticoRepository proteticoRepository,
                                  IMapper mapper,
                                  INotificador notificador,IUser user) : base(notificador , user)
        {
            _servicoRepository = servicoRepository;
            _servicoService = servicoService;
            _mapper = mapper;
            _proteticoRepository = proteticoRepository;
            _produtoRepository = produtoRepository;
            _dentistaRepository = dentistaRepository;
        }

        // GET: Servicos
        public async Task<IActionResult> Index(int? pagina, string IDPesquisa)
        {
            var _pesquisa = string.IsNullOrEmpty(IDPesquisa) ? ProteticoId : Guid.Parse(IDPesquisa);

            return View(_mapper.Map<StaticPagedList<ServicoViewModel>>(await _servicoRepository.ObterServicoPesquisaPaginado(pagina, _pesquisa)));
        }

        // GET: Servicos/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var servicoViewModel = await ObterServico(id);
            if (servicoViewModel == null)
            {
                return NotFound();
            }

            return View(servicoViewModel);
        }

        [Route("Novo-servico")]
        public IActionResult Create()
        {
            return View();
        }

        // GET: Servicos/Create
        [Route("Novo-servico/{id:guid}")]
        public IActionResult Create(Guid id, ServicoViewModel servicoViewModel)
        {
            servicoViewModel.Dentistas = _mapper.Map<DentistaViewModel>(_dentistaRepository.ObterPorId(id));
            return View(servicoViewModel);
        }

        [Route("Novo-servico")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServicoViewModel servicoViewModel)
        {
            ModelState.Remove("Dentistas"); 
            ModelState.Remove("Produtos");
            ModelState.Remove("Proteticos");

            if (!ModelState.IsValid) return View(servicoViewModel);

            var servicos = _mapper.Map<Servicos>(servicoViewModel);
          
            await _servicoService.Adicionar(servicos);

            if (!OperacaoValida()) return View(servicoViewModel);

            return View(new ServicoViewModel { Dentistas = servicoViewModel.Dentistas }); 
        }

        [Route("editar-servico/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var servicoViewModel = await ObterServico(id);
            if (servicoViewModel == null) return NotFound();

            return View(servicoViewModel);
        }

     
        [Route("editar-servico/{id:guid}")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, ServicoViewModel servicoViewModel)
        {
            if (id != servicoViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(servicoViewModel);

            var servicos = _mapper.Map<Servicos>(servicoViewModel);
            await _servicoService.Atualizar(servicos);

            if (!OperacaoValida()) return View(await ObterServico(id));

            return RedirectToAction("Index");
        }

        // GET: Servicos/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var servicoViewModel = await ObterServico(id);
            if (servicoViewModel == null)
            {
                return NotFound();
            }

            return View(servicoViewModel);
        }

        // POST: Servicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var servico = await ObterServico(id);

            if (servico == null) return NotFound();

            await _servicoService.Remover(id);

            if (!OperacaoValida()) return View(servico);

            return RedirectToAction("Index");
        }

        private bool ServicoViewModelExists(Guid id)
        {
            return _servicoRepository.Buscar(e => e.Id == id).Result.Any();
        }

        private async Task<ServicoViewModel> ObterServico(Guid id)
        {
            var _servico = _mapper.Map<ServicoViewModel>(await _servicoRepository.ObterPorId(id));
            _servico.Dentistas = _mapper.Map<DentistaViewModel>(await _dentistaRepository.ObterPorId(_servico.IDDentista));
            _servico.Proteticos = _mapper.Map<ProteticoViewModel>(await _proteticoRepository.ObterPorId(_servico.IDProtetico));
            _servico.Produtos = _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(_servico.IDProduto));
            return _servico;
        }

        public async Task<IActionResult> ObterDentistaPorDescricao(string nomeDetista)
        {
            var ListarDentista = ( await _dentistaRepository.Buscar(d => d.Nome.Contains(nomeDetista))).Select(a => new { value = a.Nome, id = a.Id }).ToList();

            return Json(ListarDentista.ToArray());
        }

        public async Task<IActionResult> ObterProdutosPorDescricao(string nomeProdutos)
        {
            var ListarProdutos = (await _produtoRepository.Buscar(d => d.Nome.Contains(nomeProdutos))).Select(a => new { value = a.Nome, id = a.Id }).ToList();

            return Json(ListarProdutos.ToArray());
        }

        public async Task<IActionResult> ObterProteticoPorDescricao(string nomeProtetico)
        {
            var ListarProtetico = (await _proteticoRepository.Buscar(d => d.Nome.Contains(nomeProtetico))).Select(a => new { value = a.Nome, id = a.Id }).ToList();

            return Json(ListarProtetico.ToArray());
        }

     
    }
}
