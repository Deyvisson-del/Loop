using Loop.Application.DTOs;
using Loop.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Loop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstagiarioController : ControllerBase
    {
        private readonly IEstagiarioService _estagiarioService;

        public EstagiarioController(IEstagiarioService estagiarioService)
        {
            _estagiarioService = estagiarioService;
        }

        // POST api/estagiario
        [HttpPost]
        public async Task<IActionResult> CadastrarEstagiario([FromBody] EstagiarioDTO estagiarioDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var novoEstagiario = await _estagiarioService.AdicionarAsync(estagiarioDTO);

            return CreatedAtAction(nameof(Details), new { id = novoEstagiario.Id }, novoEstagiario);
        }

        // GET api/estagiario
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var estagiariosDTO = await _estagiarioService.ObterTodosAsync();
            return Ok(estagiariosDTO);
        }

        // GET api/estagiario/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var estagiario = await _estagiarioService.ObterPorIdAsync(id);

            if (estagiario == null)
                return NotFound();

            return Ok(estagiario);
        }

    }
}
