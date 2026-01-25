using Loop.Domain.Entities;

namespace Loop.Application.UseCase.Administrador
{
    public class BuscarEstagiarioUseCase
    {
        private readonly IAdministradorRepository _administradorRepository;
        public BuscarEstagiarioUseCase(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }
        public Estagiario? ExecutarPorId(int id)
        {
            return _administradorRepository.ConsultarEstagiarioId(id);
        }
        public Estagiario? ExecutarPorNome(string nome)
        {
            return _administradorRepository.ConsultaEstagiarioNome(nome);
        }
    }
}