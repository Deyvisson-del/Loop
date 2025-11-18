using Loop.Application.DTOs;
using Loop.Application.Interfaces;
using Loop.MVC.Models;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Loop.MVC.Controllers
{
    public class EstagiarioController : Controller
    {
        private readonly IEstagiarioService _estagiarioService;
        private readonly IMapper _mapper;

        public EstagiarioController(IEstagiarioService estagiarioService, IMapper mapper)
        {
            _estagiarioService = estagiarioService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarEstagiario(EstagiarioDTO estagiarioDTO)
        {   
            if (!ModelState.IsValid)
            {
                return View(estagiarioDTO);
            }
            var novoEstagiario = await _estagiarioService.AdicionarAsync(estagiarioDTO);

            return RedirectToAction("CadastrarEstagiario");
        }


        public async Task<IActionResult> Index()
        {
            var estagiariosDTO = await _estagiarioService.ObterTodosAsync();
            //var viewModel = estagiariosDTO.Adapt<IEnumerable<EstagiarioViewModel>>();
            return View(estagiariosDTO);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var estagiario = await _estagiarioService.ObterPorIdAsync(id);
            if (estagiario == null) return NotFound();

            return View(estagiario);
        }
    }
}
