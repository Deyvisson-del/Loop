using Loop.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Loop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IEstagiarioService _estagiarioService;

        public HomeController(IEstagiarioService estagiarioService)
        {
            _estagiarioService = estagiarioService;
        }
        // GET api/home
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var estagiariosDTO = await _estagiarioService.ObterTodosAsync();
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
