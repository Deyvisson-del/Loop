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

       

        // GET api/estagiario
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var estagiariosDTO = await _estagiarioService.ObterTodosAsync();
            return Ok(estagiariosDTO);
        }

        //GET api/estagiario/1}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var estagiario = await _estagiarioService.ObterPorIdAsync(id);
            if (estagiario == null)
                return NotFound();
            return Ok(estagiario);
        }


        // PUT api/estagiario/1
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] EstagiarioDTO estagiarioDTO)
        {

            if (id != estagiarioDTO.Id)
                return BadRequest("ID inválido.");

            await _estagiarioService.AtualizarAsync(id, estagiarioDTO);
            return NoContent();
        }


        // DELETE api/estagiario/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var estagiario = await _estagiarioService.ObterPorIdAsync(id);
            if (estagiario == null)
                return NotFound();
            await _estagiarioService.RemoverAsync(id);
            return NoContent();
        }

    }
}
