using Loop.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Loop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {

        private readonly IEstagiarioService _estagiarioService;
        private readonly IAdministradorService _administradorService;

        // GET api/Estagiario
        [HttpGet]
        [Route("api/estagiario")]
        public async Task<IActionResult> IndexAsync()
        {
            var estagiariosDTO = await _administradorService.ObterTodosEstagiariosAsync();
            return Ok(estagiariosDTO);
        }

        // POST api/home
        [HttpPost]
        public IActionResult Index([FromBody] string userInput)
        {
            return Ok(new { redirect = "/api/estagiario" });
        }
    }
}
