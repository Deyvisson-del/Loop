
using Loop.Application.Services;
using Loop.Domain.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Loop.API.MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstagiarioController : Controller
    {
        private readonly EstagiarioService _estagiarioService;

        public EstagiarioController(EstagiarioService estagiarioService)
        {
            _estagiarioService = estagiarioService;
        }

        [HttpPost]
        [Route("/BaterEntrada")]
        public IActionResult BaterEntrada()
        {
            _estagiarioService.BaterEntrada();
            return Ok("Registro entrada concluído");
        }

        [HttpPost]
        [Route("/BaterSaida")]
        public IActionResult BaterSaida()
        {
            _estagiarioService.BaterSaida();

            return Ok("Registro entrada concluído");
        }
    }
}