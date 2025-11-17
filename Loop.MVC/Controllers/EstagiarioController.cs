using Loop.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Loop.MVC.Controllers
{
    public class EstagiarioController : Controller
    {
        private readonly IEstagiarioService _estagiarioService;

        public EstagiarioController(IEstagiarioService estagiarioService)
        {
            _estagiarioService = estagiarioService;
        }

        public async Task<IActionResult> Index()
        {
            var estagiarios = await _estagiarioService.ObterTodosAsync();
            return View(estagiarios);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var estagiario = await _estagiarioService.ObterPorIdAsync(id);
            if (estagiario == null) return NotFound();

            return View(estagiario);
        }
    }
}
