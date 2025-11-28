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






        [HttpPost("bater-entrada")]
        public async Task<IActionResult> BaterEntrada([FromQuery] int estagiarioId)
        {
            var frequencia = await _estagiarioService.BaterEntradaAsync(estagiarioId);
            return Ok(frequencia);
        }


        [HttpPost("bater-saida")]
        public async Task<IActionResult> BaterSaida([FromQuery] int estagiarioId)
        {
            var frequencia = await _estagiarioService.BaterSaidaAsync(estagiarioId);
            return Ok(frequencia);
        }

        [HttpGet("visualizar-relatorio")]
        public async Task<IActionResult> VisualizarRelatorio([FromQuery] int estagiarioId)
        {
            var relatorio = await _estagiarioService.VisualizarRelatorio(estagiarioId);
            return Ok(relatorio);
        }

    }
}
