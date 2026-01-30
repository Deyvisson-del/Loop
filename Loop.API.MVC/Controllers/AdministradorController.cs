using Loop.Application.DTOs;
using Loop.Application.UseCase.Administrador;
using Loop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Loop.API.MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdministradorController : Controller
    {
        private readonly CriarEstagiarioADM _criarEstagiarioADM;

        public AdministradorController(CriarEstagiarioADM criarEstagiarioADM)
        {
            _criarEstagiarioADM = criarEstagiarioADM;
        }

        [HttpPost]
        [Route("CriarEstagiario")]
        public IActionResult CriarEstagiario([FromBody] EstagiarioDTO estagiarioDTO)
        {
            var estagiario = new Estagiario(estagiarioDTO.Nome!, estagiarioDTO.Email!, estagiarioDTO.Senha!);
            _criarEstagiarioADM.Executar(estagiario);
            return CreatedAtAction(nameof(CriarEstagiario), new { id = estagiario.Id }, estagiario);
        }
    }
}
