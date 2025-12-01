using Loop.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Loop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        
        // GET api/Estagiario
        [HttpGet]
        [Route("api/estagiario")]
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
