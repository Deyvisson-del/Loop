using Loop.Application.DTOs;
using Loop.Application.Interfaces;
using Loop.Application.Services;
using Loop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Loop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GestorController : Controller
    {
        private readonly IGestorService _gestorService;
        private readonly IEstagiarioService _estagiarioService;
        public GestorController(IGestorService gestorService, IEstagiarioService estagiarioService)
        {
            _gestorService = gestorService;
            _estagiarioService = estagiarioService;
        }

        // POST api/estagiario
        [HttpPost]
        [Route("api/CriarEstagiario/")]
        public async Task<IActionResult> Create([FromBody] Estagiario estagiario)
        {
            if (estagiario == null)
                return BadRequest("EstagiarioDTO é nulo.");

            return View(); 
        }



    }
}
