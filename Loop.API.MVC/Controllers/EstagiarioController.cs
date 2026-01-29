using Microsoft.AspNetCore.Mvc;

namespace Loop.API.MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstagiarioController : ControllerBase
    {

        [HttpPost]
        [Route("/MostrarEstagiarios/")]
        public IActionResult MostrarTodosEstagiarios()
        {
            return Ok();
        }
    }
}