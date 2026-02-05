using Loop.Application.DTOs;
using Loop.Application.Services;
using Microsoft.AspNetCore.Mvc;
namespace Loop.API.MVC.Controllers.Frequencia
{
    [ApiController]
    [Route("/api/[controller]")]
    public class FrequenciaController : Controller
    {
        private readonly FrequenciaService _frequenciaService;
        public FrequenciaController(FrequenciaService frequenciaService)
        {
            _frequenciaService = frequenciaService;
        }
        [HttpPost]
        [Route("Entrada")]
        public IActionResult RegistrarEntrada([FromBody] FrequenciaDTO frequenciaDTO)
        {
            var datahora = frequenciaDTO.dataHoraEntrada ?? DateTime.Now;
            var frequencia = _frequenciaService.RegistrarEntrada(frequenciaDTO.EstagiarioId, datahora);
            return Ok(frequencia);
        }
        [HttpPost]
        [Route("Saida")]
        public IActionResult RegistrarSaida([FromBody] FrequenciaDTO frequenciaDTO)
        {
            var datahora = frequenciaDTO.dataHoraEntrada ?? DateTime.Now;
            var frequencia = _frequenciaService.RegistrarSaida(frequenciaDTO.EstagiarioId, datahora);
            return Ok(frequencia);
        }
    }
}