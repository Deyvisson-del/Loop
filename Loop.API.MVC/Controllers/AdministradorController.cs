using Loop.Application.DTOs;
using Loop.Application.Services;
using Loop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Loop.API.MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdministradorController : Controller
    {
        private readonly AdministradorService _administradorService;

        public AdministradorController(AdministradorService administradorService)
        {
            _administradorService = administradorService;
        }

        [HttpPost]
        [Route("CriarEstagiario")]
        public IActionResult CriarEstagiario([FromBody] UserDTO userDTO)
        {
            var estagiario = new Estagiario(userDTO.Nome, userDTO.Email, userDTO.Senha);
            _administradorService.CriarEstagiario(estagiario);
            return CreatedAtAction(nameof(CriarEstagiario), new { id = estagiario.Id }, estagiario);
        }

        [HttpPost]
        [Route("CriarGestor")]
        public IActionResult CriarGestor([FromBody] UserDTO userDTO)
        {
            var gestor = new Gestor(userDTO.Nome, userDTO.Email, userDTO.Senha);
            _administradorService.CriarGestor(gestor);
            return CreatedAtAction(nameof(CriarEstagiario), new { id = gestor.Id }, gestor);
        }

        [HttpGet]
        [Route("ListarEstagiarios")]
        public IEnumerable<Estagiario> ListarEstagiarios()
        {
            return _administradorService.ListaDeEstagiarios();
        }

        [HttpGet]
        [Route("ListarGestores")]
        public IEnumerable<Gestor> ListarGestores()
        {
            return _administradorService.ListaDeGestores();
        }

        [HttpGet]
        [Route("BuscarIdEstagiario/{id}")]
        public Estagiario? BuscarIdEstagiario(int id)
        {
            return _administradorService.BuscarEstagiarioPorId(id);
        }

        [HttpGet]
        [Route("BuscarIdGestor/{id}")]
        public Gestor? BuscarIdGestor(int id)
        {
            return _administradorService.BuscarGestorPorId(id);
        }

        [HttpDelete]
        [Route("DeletarEstagiario/{id}")]
        public void DeletarEstagiario(int id)
        {
            _administradorService.DeletarEstagiario(id);
        }

        [HttpDelete]
        [Route("DeletarGestor/{id}")]
        public void DeletarGestor(int id)
        {
            _administradorService.DeletarGestor(id);
        }

    }
}
