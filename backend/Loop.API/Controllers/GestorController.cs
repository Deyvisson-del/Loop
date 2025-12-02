using Loop.Application.DTOs;
using Loop.Application.Interfaces;
using Loop.Application.Services;
using Loop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Loop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GestorController : ControllerBase
    {
        private readonly IGestorService _gestorService;
        private readonly IEstagiarioService _estagiarioService;
        public GestorController(IGestorService gestorService)
        {
            _gestorService = gestorService;
        }

        // POST api/estagiario
        [Route("api/CriarEstagiario/")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Estagiario estagiario)
        {
            if (estagiario == null)
                return BadRequest("EstagiarioDTO é nulo.");


            //var createdEstagiario = await _gestorService.CriarEstagiarioAsync(estagiario);
            //    CreatedAtAction(nameof(GetById), new { id = createdEstagiario.Id }, createdEstagiario);
            return null; 
        }



    }
}
